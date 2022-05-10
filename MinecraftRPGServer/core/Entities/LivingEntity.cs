using MineServer;
using Packets.Play;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Items;
using Inventory;

public class LivingEntity : Entity
{
    public Guid EntityUUID = Guid.NewGuid();
    private float maxHealth = 20;
    private float health = 20;
    public virtual float HeadYaw { get; set; }
    public virtual float MaxHealth 
    {
        get => maxHealth; 
        set
        {
            maxHealth = value;
            Health = Math.Min(Health, maxHealth);
            lock (whoViewMe)
            {
                foreach (var player in whoViewMe)
                    SendMaxHealth(player.network);
            }
        }
    }
    public virtual float RegenerationPerSecond { get; set; } = 1;
    public virtual float Health 
    {
        get => health;
        set
        {
            value = Math.Min(Math.Max(value, 0), MaxHealth);
            if (value != health)
            {
                var oldHealth = health;
                health = value;
                OnHealthChanged?.Invoke(this, health, oldHealth);
            }
        }
    }

    protected Hologram HealthHolo;
    protected virtual bool HasHealthHolo => true;
    protected virtual v3f HoloOffset => v3f.zero;

    public List<Player> whoViewMe = new List<Player>();

    public virtual Item[] Armor { get; } = new Item[4];
    public virtual Item MainHand { get; } = null;
    public virtual Item OffHand { get; } = null;

    public virtual Sound HurtSound => new Sound(SoundID.entity_player_hurt, Categories.PLAYERS);
    public virtual Sound DeathSound => new Sound(SoundID.entity_player_death, Categories.PLAYERS);

    public delegate void HealthChangedArgs(LivingEntity sender, float newHealth, float oldHealth);
    public event HealthChangedArgs OnHealthChanged;
    public LivingEntity(World world) : base(world) 
    {
        if (HasHealthHolo)
        {
            OnPositionChanged += LivingEntity_OnPositionChanged;
            OnDestroy += LivingEntity_OnDestroy;
            OnHealthChanged += LivingEntity_OnHealthChanged;
        }
        OnTick += LivingEntity_OnTick;
    }

    private void LivingEntity_OnTick(Entity entity, long tick)
    {
        if (tick % 20 == 0)
        {
            if (Health > 0 && Health < MaxHealth)
                Health += RegenerationPerSecond;
        }
        if (HealthHolo != null && health == maxHealth)
        {
            HealthHolo.Destroy();
            HealthHolo = null;
        }
    }

    private void LivingEntity_OnHealthChanged(LivingEntity sender, float newHealth, float oldHealth)
    {
        if (newHealth <= 0)
        {
            Death();
        }
        else
        {
            lock (meta)
            {
                meta["Health"] = newHealth / maxHealth * 20;
                ForceUpdateMetadata();
            }
            if (newHealth < oldHealth)
                TakeDamage();
            HealthHolo?.SetText(HoloText);
        }
    }

    private void LivingEntity_OnDestroy()
    {
        OnPositionChanged -= LivingEntity_OnPositionChanged;
        OnHealthChanged -= LivingEntity_OnHealthChanged;
        OnTick -= LivingEntity_OnTick;
        OnDestroy -= LivingEntity_OnDestroy;
        HealthHolo?.Destroy();
    }

    protected void LivingEntity_OnPositionChanged(v3f lastposition, v3f newposition)
    {
        if (HealthHolo != null)
            HealthHolo.Position = newposition + v3f.up * BoxCollider.y + HoloOffset;
    }
    protected virtual void TakeDamage()
    {
        if (HealthHolo == null && 
            health != maxHealth)
        {
            HealthHolo = Hologram.Create(world, position + v3f.up * BoxCollider.y + HoloOffset, HoloText);
        }
        foreach (var player in whoViewMe)
        {
            player.PlaySound(HurtSound, Position, 1f / v3f.Distance(position, player.position));
            SendPlayAnimation(EntityAnimation_clientbound.AnimationType.TakeDamage, player.network);
        }
    }
    protected virtual void Death()
    {
        lock (meta)
        {
            meta["Health"] = 0;
            meta["Pose"] = Pose.DYING;
            ForceUpdateMetadata();
        }
        HealthHolo?.Destroy();
        Task.Run(async () =>
        {
            await Task.Delay(1000);
            Destroy();
        });
    }

    public void SendPlayAnimation(EntityAnimation_clientbound.AnimationType animation, NetworkProvider net)
    {
        net.Send(new EntityAnimation_clientbound()
        {
            EntityID = EntityID,
            Animation = animation
        });
    }
    public void ForceUpdateMetadata()
    {
        foreach (var player in whoViewMe)
            player.entitiesController.SendMetadataChanges(this);
    }
    private string HoloText
    {
        get
        {
            const int len = 20;
            return "&c" + new string('|', len).Insert((int)(health / maxHealth * len), "&4");
        }
    }
    public virtual void SendMaxHealth(NetworkProvider net)
    {
        net.Send(new EntityProperties()
        {
            EntityID = EntityID,
            Properties = new EntityProperties.Property[]
            {
                new EntityProperties.Property()
                {
                    Key = "generic.max_health",
                    Value = 20,
                }
            }
        });
    }

    private EntityEquipment getEquipments()
    {
        Item[] equipments = new Item[]
        {
            MainHand,
            OffHand,
            Armor[3],
            Armor[2],
            Armor[1],
            Armor[0],
        };
        List<EntityEquipment.Equipment> list = new List<EntityEquipment.Equipment>();
        for (int k = 0; k < equipments.Length; k++)
        {
            list.Add(new EntityEquipment.Equipment()
            {
                Item = equipments[k] != null ? equipments[k] : default,
                Slot = (EntityEquipment.EquipmentSlot)k
            });
        }
        var writer = new ArrayWriter(true);
        int index = 0;
        foreach (var t in list)
        {
            if (index < list.Count - 1)
                t.Slot |= EntityEquipment.EquipmentSlot.NextPresent;
            writer.Write(t);
            index++;
        }
        var data = writer.ToArray();
        return new EntityEquipment()
        {
            EntityID = EntityID,
            equipmentArray = data
        };
    }
    public void SendEquipments()
    {
        var packet = getEquipments();
        if (packet.equipmentArray.bytes.Length > 0)
            foreach (var player in whoViewMe)
                player.network.Send(packet);
    }
    public void SendEquipments(NetworkProvider net)
    {
        var packet = getEquipments();
        if (packet.equipmentArray.bytes.Length > 0)
            net.Send(packet);
    }
}
