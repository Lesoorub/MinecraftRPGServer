using System.Collections.Concurrent;
using static MineServer.FastByteArrayExtensions;

public class Hologram
{
    public int ID => entity.EntityID;
    private IHologram entity;
    private string text;
    public string Text { get => text; set => SetText(value); }
    public bool Visible { get => entity.Visible; set => entity.Visible = value; }
    public v3f Position
    {
        get => entity.Position;
        set => entity.Position = value;
    }
    public Hologram(Player player, v3f position, string text)
    {
        entity = new ClientboundHologram(player, position, text);
        SetText(text);
    }
    public Hologram(World world, v3f position, string text)
    {
        entity = new HologramEntity(world)
        {
            Position = position,
        };
        SetText(text);
    }

    public void SetText(string text)
    {
        entity.SetText(text);
        this.text = text;
    }
    public void Destroy()
    {
        list.TryRemove(entity.EntityID, out _);
        entity.Destroy();
    }

    public static ConcurrentDictionary<int, Hologram> list = new ConcurrentDictionary<int, Hologram>();
    public static Hologram Create(World world, v3f position, string text)
    {
        var h = new Hologram(world, position, text);
        list.TryAdd(h.entity.EntityID, h);
        return h;
    }
    public static Hologram Create(Player player, v3f position, string text)
    {
        var h = new Hologram(player, position, text);
        list.TryAdd(h.entity.EntityID, h);
        return h;
    }
    public static void Destroy(int ID)
    {
        if (list.TryGetValue(ID, out var h)) 
            h.Destroy();
    }
    public interface IHologram
    {
        int EntityID { get; }
        v3f Position { get; set; }
        bool Visible { get; set; }
        void SetText(string text);
        void Destroy();
    }
    private class HologramEntity : Entities.ArmorStand, IHologram
    {
        protected override bool HasHealthHolo => false;
        public bool visible = true;
        public bool Visible 
        { 
            get => visible;
            set
            {
                visible = value;
                meta["isCustomNameVisible"] = visible;
                ForceUpdateMetadata();
            }
        } 

        public HologramEntity(World world) : base(world)
        {
            meta.SetFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsInvisible);
            //meta.SetFlag("armorStandStatus", (byte)(ArmorStandMetadata.ArmorStandStatus.isSmall | ArmorStandMetadata.ArmorStandStatus.IsMarker));
            meta.SetFlag("armorStandStatus", (byte) ArmorStandMetadata.ArmorStandStatus.IsMarker);
        }

        public void SetText(string text)
        {
            meta["CustomName"] = new Chat?(Chat.ColoredText(text));
            meta["isCustomNameVisible"] = Visible;
        }
    }
    private class ClientboundHologram : IHologram
    {
        public int EntityID { get; set; }

        public v3f position = v3f.zero; 
        public bool visible = true;
        public bool Visible
        {
            get => visible;
            set
            {
                visible = value;
                network.Send(new Packets.Play.EntityMetadata()
                {
                    EntityID = EntityID,
                    Metadata = Combine(new byte[][]
                    {
                        new byte[] { 3, 7, (byte)(visible ? 1 : 0) }, //Text visible
                        new byte[] { 0xFF }
                    })
                });
            }
        }
        public v3f Position 
        {
            get => position;
            set => SetPosition(value);
        }

        public EntityMetadata meta { get; }
        MineServer.NetworkProvider network;
        public ClientboundHologram(Player player, v3f position, string text)
        {
            EntityID = Entity.GetUniqEnityID();
            network = player.network;

            var spawnPacket = new Packets.Play.SpawnLivingEntity()
            {
                EntityID = EntityID,
                EntityUUID = System.Guid.NewGuid(),
                HeadYaw = new Angle(0),
                Yaw = new Angle(0),
                Pitch = new Angle(0),
                Type = 1,
                VelocityX = 0,
                VelocityY = 0,
                VelocityZ = 0,
                X = position.x,
                Y = position.y,
                Z = position.z
            };
            var metadataPacket = new Packets.Play.EntityMetadata()
            {
                EntityID = EntityID,
                Metadata = Combine(new byte[][]
                {
                    new byte[] { 0, 0, 0x20 },//IsInvisible
                    new byte[] { 15, 0, 0x10 },//IsMarker
                    new byte[] { 0xFF }
                })
            };
            network.Send(spawnPacket.ToByteArray().Combine(metadataPacket.ToByteArray()));

            this.position = position.Clone();
            SetText(text);
        }

        public void Destroy()
        {
            network.Send(new Packets.Play.DestroyEntities()
            {
                Entities = new MineServer.VarInt[] { new MineServer.VarInt(EntityID) }
            });
        }

        public void SetText(string text)
        {
            network.Send(new Packets.Play.EntityMetadata()
            {
                EntityID = EntityID,
                Metadata = Combine(new byte[][]
                {
                    new byte[] { 2, 5, 1 }, Chat.ColoredText(text).ToByteArray(), //Text
                    new byte[] { 3, 7, (byte)(visible ? 1 : 0) }, //Text visible
                    new byte[] { 0xFF }
                })
            });
        }
        void SetPosition(v3f newPosition)
        {
            position = newPosition.Clone();
        }
    }
}
