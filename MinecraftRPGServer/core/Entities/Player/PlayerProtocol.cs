﻿using System.Collections.Generic;
using System.Linq;
using MineServer;
using Packets.Play;
using System;
using System.Threading.Tasks;

public class PlayerProtocol : LivingEntity, IClient, IEntityProtocol
{
    public NetworkProvider network { get; set; }
    public MineServer.MineServer server { get; set; }
    public RPGServer rpgserver { get => server as RPGServer; }
    public int protocolVersion { get; set; }

    protected GamemodeType gamemode = GamemodeType.Survival;
    protected v2f rotation = new v2f(0, 0);
    public GamemodeType Gamemode { get => gamemode; set { gamemode = value; SendChangeGamemode(value); } }
    public override v2f Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            SendPlayerPositionAndLook();
        }
    }
    public bool IsSneaking
    {
        get => ((EntityMetadata.EntityStatus)meta["entityStatus"]).HasFlag(EntityMetadata.EntityStatus.isCrouching);
        set
        {
            if (value)
            {
                meta.SetFlag("entityStatus", (byte)EntityMetadata.EntityStatus.isCrouching);
                meta["Pose"] = Pose.SNEAKING;
            }
            else
            {
                meta.RemoveFlag("entityStatus", (byte)EntityMetadata.EntityStatus.isCrouching);
                meta["Pose"] = (byte)0;
            }
            SendMetadataUpdate();
        }
    }
    /// <summary>
    /// no sprint - 4.316 blocks per second
    /// with sprint - 5.612 blocks per second
    /// </summary>
    public bool IsSprinting
    {
        get => ((EntityMetadata.EntityStatus)meta["entityStatus"]).HasFlag(EntityMetadata.EntityStatus.isCrouching);
        set
        {
            if (value)
            {
                meta.SetFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsSprinting);
            }
            else
            {
                meta.RemoveFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsSprinting);
            }

            SendMetadataUpdate();
        }
    }
    public override float MaxHealth 
    { 
        get => base.MaxHealth; set 
        { 
            base.MaxHealth = value; 
            if (Health > base.MaxHealth)
                Health = base.MaxHealth;
        } 
    }
    public override float Health 
    { 
        get => base.Health;
        set
        {
            if (value < base.Health)
            {
                //Отправить видимым игрокам анимацию удара по мне
                PlayAnimation(EntityAnimation_clientbound.AnimationType.TakeDamage);
                lastHealthReduced = Time.GetTime();
            }
            if (value > MaxHealth)
                value = MaxHealth;
            if (Math.Abs(value - base.Health) > RegenerationPerSecond)
                Console.WriteLine($"EID: {EntityID}, HP: {base.Health} -> {value}");
            base.Health = value;

            if (base.Health <= 0)
                RespawnPlayer();
        }
    }
    public long lastHealthReduced;
    public float RegenerationPerSecond = 1;
    public v3f ForwardDir => v3f.FromRotationInvertX(rotation);
    public v3f EyePosition => Position + new v3f(0, IsSneaking ? 1.5f : 1.62f, 0);
    private byte selectedSlot = 0;
    public byte SelectedSlot 
    { 
        get => selectedSlot; 
        set
        {
            selectedSlot = Math.Max(Math.Min(value, (byte)9), (byte)0);
            SendEquipments();
        }
    }
    public EntityView view = new EntityView();

    public Weather currentWeather;

    public KeepAliveModule keepAlive = new KeepAliveModule();
    public WorldLoaderController worldController = new WorldLoaderController();
    public EntitiesController entitiesController = new EntitiesController();

    public PlayerSettings settings;
    public bool isInit => settings.ViewDistance != 0;
    public Guid PlayerUUID;

    public PlayerInventory inventory = new PlayerInventory();
    public Item SelectedItem => inventory.Hotbar[selectedSlot];
    public Item OffHandSelectedItem => inventory.slots[45];
    public int LastStateID = 1;

    public long PreviousRecievedMetadata = 0;

    public delegate void ConnectedArgs();
    public event ConnectedArgs OnConnected;

    public PlayerProtocol(World world) : base(world)
    {
        currentWeather = new Weather(this);
        OnConnected += PlayerProtocol_OnConnected;
        //Привязка функционала перемещения игрока на клиенте при изменении позиции чем-либо
        OnPositionChanged += PlayerProtocol_OnPositionChanged;

        keepAlive.Init(this as Player);
        worldController.Init(this as Player);
        entitiesController.Init(this as Player);
    }

    private void PlayerProtocol_OnPositionChanged(v3f lastposition, v3f newposition)
    {
        if (v3f.Distance(lastposition, newposition) < 8)
        {
            //Это не телепортация
            SendPlayerPositionAndLook();//Отправить клиенту его текущую позицию и вращение
            entitiesController.UpdateLoadedEntitiesLoad();//Обновить видимость энтити вокруг
        }
        else
        {
            //Это телепортация
            TeleportTo(newposition.Clone());
        }
    }

    public void InvokeOnConnected() => OnConnected?.Invoke();
    private void PlayerProtocol_OnConnected()
    {
        rpgserver.OnLogOut += Rpgserver_OnLogOut;
        inventory.OnSlotChanged += (item, index) =>
        {
            if ((index >= 5 && index <= 8) ||
                (index >= 36 && index <= 45))
                SendEquipments();
        };
        inventory.OnDropStack += (item) =>
        {
            DropItem(inventory.slots.ToList().IndexOf(item));
        };
        SendHeldItemChanged();//16
        network.Send(new Tags()
        {
            tags = SupportedProtocol.allprotocols[protocolVersion].Tags
        });//18
        network.Send(new DeclareCommands()
        {
            data = Commands.DeclareCommands
        });//20
        SendPlayerPositionAndLook();//22
        rpgserver.tab.SendPlayers(network);
        worldController.SendUpdateViewPosition();//25
        worldController.SendWorld();//26-27
        SendPlayerPositionAndLook();//30
        //Создать все сущности у игрока
        entitiesController.UpdateLoadedEntitiesLoad();//34+
        SendInventory();
        SendUpdateHealth();
        var player = this as Player;
        Player.players.TryAdd(player.data.username, player);

        SendEquipments();
        SendMetadataUpdate();
    }
    public void DropItem(int index)
    {
        Entities.Item.Spawn(world, inventory.slots[index], Position + new v3f(0, 1.5f, 0), ForwardDir * 0.25f);
    }
    private void Rpgserver_OnLogOut(Player player)
    {
        rpgserver.OnLogOut -= Rpgserver_OnLogOut;

        var arrayWithSelf = new int[] { EntityID };
        Player.players.TryRemove(player.data.username, out var _);
        //Уничтожить себя у других игроков
        foreach (var entitypair in view.players)
        {
            if (entitypair.Value.entity.isInit)
                entitypair.Value.entity.SendDestroyEntities(arrayWithSelf);
        }
    }

    public static Guid FromLoginName(string login) => new Guid(login.GetSha1().Take(16));
    public void SendPlayerPositionAndLook()
    {
        network.Send(new PlayerPositionAndLook_clientbound()
        {
            X = position.x,
            Y = position.y,
            Z = position.z,
            Yaw = rotation.x,
            Pitch = rotation.y,
            TeleportID = TeleportConfirm.NextTeleportID,
            DismountVehicle = false
        });
    }
    public void SendHeldItemChanged()
    {
        network.Send(new HeldItemChange()
        {
            Slot = selectedSlot,
        });
    }

    /// <summary>
    /// Устанавливает игроку новую позицию без отправки ему его позиции
    /// Пример:
    ///    Если игрок присылает свою новую позицию, мы должны ее 
    ///   приминить и нам не требуется отправлять ее обратно игроку
    /// </summary>
    /// <param name="newposition"></param>
    public void ApplyNewPosition(v3f newposition)
    {
        if ((position - newposition).SqrMagnitude == 0) return;
        var lastcpos = ChunkPos;
        position = newposition;
        if (!lastcpos.Equals(ChunkPos))
            OnChunkChanged_Invoke(lastcpos, ChunkPos);
    }
    public void ApplyNewPositionAndRotation(v3f newposition, v2f newrotation)
    {
        ApplyNewPosition(newposition);
        ApplyNewRotation(newrotation);
    }
    public void ApplyNewRotation(v2f newrotation)
    {
        rotation = newrotation;
    }
    /// <summary>
    /// Асинхронная функция реализующая корректную телепортацию игрока. Вызывать если собираетесь передвинуть игрока более чем на 8 блоков
    /// </summary>
    /// <param name="newposition">Новая позиция игрока</param>
    public async void TeleportTo(v3f newposition)
    {
        await Task.Run(async () =>
        {
            ApplyNewPosition(newposition);
            worldController.UnloadChunks();//Разгружает чанки
            await Task.Delay(100);
            SendPlayerPositionAndLook();//Передает новую позицию клиенту
            await Task.Delay(100);
            worldController.SendUpdateViewPosition();//Перемещает позицию подгружаемых чанков у клиента
            await Task.Delay(100);
            worldController.SendWorld();//Отправляет новый мир
            await Task.Delay(100);
            entitiesController.UpdateLoadedEntitiesLoad();//Обновить видимость энтити вокруг
        });
    }

    public void BeginRecievePackets()
    {
        network.OnPacketRecieved += OnPacketRecievedPackets;
    }
    public void EndRecievePackets()
    {
        network.OnPacketRecieved -= OnPacketRecievedPackets;
    }
    public void OnPacketRecievedPackets(BytesBasedPacket packet)
    {
#if !DEBUG
        try
        {
#endif
        var minecraft_packets = MinecraftPacket.Parse(packet);
        foreach (var mpacket in minecraft_packets)
        {
            //Console.WriteLine($"[in] packet_id=0x{((int)mpacket.packet_id):X}");
            if (RPGServer.registered.TryGetValue(State.Play, out var dict) &&
                dict.TryGetValue(mpacket.packet_id, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.OnPacketRecieved(this,
                        (IPacket)PacketListener.Parse(
                            mpacket,
                            RPGServer.BoundToServer[
                                RPGServer.IndexFromPacketIdAndState(
                                    mpacket.packet_id,
                                    State.Play)]));
                }
            }
        }
#if !DEBUG
        }
        catch (Exception ex)
        {
            network.Disconnect();
        }
#endif
    }

    /// <summary>
    /// Sent when any player is struck by an arrow
    /// </summary>
    public void SendArrayHitSound() =>
        SendChangeGameState(ChangeGameState.ReasonType.ArrowHitPlayer, 0);
    public void SendChangeGamemode(GamemodeType newgm) => 
        SendChangeGameState(ChangeGameState.ReasonType.ChangeGamemode, (byte)newgm);
    public void SendChangeGameState(ChangeGameState.ReasonType reason, float value)
    {
        network.Send(new ChangeGameState()
        {
            Reason = reason,
            Value = value
        });
    }
    public void SendEnableRespawnScreen(bool isImmediatelyRespawn) =>
        SendChangeGameState(ChangeGameState.ReasonType.EnableRespawnScreen, isImmediatelyRespawn ? 1 : 0);

    public void EchoIntoChatFromServer(string message) =>
        Echo(Guid.Empty, ChatMessage_clientbound.PositionType.chat, Chat.ColoredText(message));
    public void EchoIntoChat(string message, Guid senderPlayerUUID) =>
        Echo(senderPlayerUUID, ChatMessage_clientbound.PositionType.chat, Chat.ColoredText(message));
    public void EchoSystemMessage(string msg) =>
        Echo(Guid.Empty, ChatMessage_clientbound.PositionType.system_message, Chat.ColoredText(msg));
    public void Echo(Guid sender, ChatMessage_clientbound.PositionType pos, Chat msg) =>
        network.Send(new ChatMessage_clientbound()
        {
            Sender = sender,
            JSONData = msg.ToString(),
            position = pos
        });

    public void SendSpawn(NetworkProvider[] networks)
    {
        var t = new SpawnPlayer()
        {
            EntityID = EntityID,
            X = Position.x,
            Y = Position.y,
            Z = Position.z,
            Pitch = new Angle(Rotation.y),
            Yaw = new Angle(Rotation.x),
            PlayerUUID = PlayerUUID
        };
        foreach (var network in networks)
            network.Send(t);
    }
    public void SendDestroyEntities(IEnumerable<int> entities)
    {
        if (entities.Count() == 0) return;
        network.Send(new DestroyEntities()
        {
            Entities = entities.Select(x => new VarInt(x)).ToArray()
        });
        view.Remove(entities);
        foreach (var entity in entities)
        {
            Console.WriteLine($"Destroy entity with EID={entity}");
        }
    }
    /// <summary>
    /// Обновляет список загруженных энтити. Удаляет энтити вне зоны прогрузки и добавляет энтити в зоне прогрузки.
    /// </summary>

    public override void Tick()
    {
        entitiesController.Tick();
        //2 times per second
        if (rpgserver.currentTick % 10 == 0)
        {
            Health += RegenerationPerSecond / 2;

            Echo(Guid.Empty,
                ChatMessage_clientbound.PositionType.game_info,
                Chat.ColoredText($"&c{Health:N1}/{MaxHealth:N1}&f"));
            SendUpdateHealth();

        }
    }
    public void SendInventory()
    {
        network.Send(new WindowItems()
        {
            WindowID = (byte)inventory.WindowID,
            slots = inventory.slots.Select(x => (Slot)x).ToArray(),
            CarriedItem = inventory.CarriedItem,
            StateID = LastStateID
        });
    }

    public void SetFire(bool onFire)
    {
        if (onFire)
            meta.SetFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsOnFire);
        else
            meta.RemoveFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsOnFire);

        SendMetadataUpdate();
    }
    public void SendMetadataUpdate()
    {
        var playermeta = (PlayerMetadata)meta;
        var now = Time.GetTime();
        bool Send(long last, NetworkProvider net)
        {
            var changes = playermeta.GetMetadataChanges(last);
            if (changes.Length > 1)
            {
                net.Send(new Packets.Play.EntityMetadata()
                {
                    EntityID = EntityID,
                    Metadata = changes
                });
                return true;
            }
            return false;
        }

        //Отправляю себе свои изменения метадаты
        if (Send(PreviousRecievedMetadata, network))
            PreviousRecievedMetadata = now;
        //Отправляю всем видимым игрокам свои изменения метадаты
        foreach (var loaded_ent_pair in view.players)
            if (Send(loaded_ent_pair.Value.PreviousMetadataTime, loaded_ent_pair.Value.entity.network))
                loaded_ent_pair.Value.PreviousMetadataTime = now;
    } 

    public void SendPlayAnimation(EntityAnimation_clientbound.AnimationType animation, NetworkProvider net)
    {
        net.Send(new EntityAnimation_clientbound()
        {
            EntityID = EntityID,
            Animation = animation
        });
    }
    public void PlayAnimation(EntityAnimation_clientbound.AnimationType animation) =>
        BroadcastInLoadedPlayers((other_player) => SendPlayAnimation(animation, other_player.network));

    public void BroadcastInLoadedPlayers(IPacket packet)
    {
        foreach (var loaded_entity in view.players)
            loaded_entity.Value.entity.network.Send(packet);
    }
    public void BroadcastInLoadedPlayers(IPacket packet, Func<Player, bool> predicate)
    {
        foreach (var loaded_entity in view.players)
            if (predicate(loaded_entity.Value.entity))
                loaded_entity.Value.entity.network.Send(packet);
    }
    public void BroadcastInLoadedPlayers(Action<Player> action)
    {
        foreach (var loaded_entity in view.players)
            action(loaded_entity.Value.entity);
    }
    public void BroadcastInLoadedPlayers(Action<Player> action, Func<Player, bool> predicate)
    {
        foreach (var loaded_entity in view.players)
            if (predicate(loaded_entity.Value.entity))
                action(loaded_entity.Value.entity);
    }

    public IEnumerable<Player> LoadedPlayers => view.players.Select(x => x.Value.entity);
    public void SendEquipments()
    {
        Item[] equipments = new Item[]
        {
            SelectedItem,
            OffHandSelectedItem,
            inventory.Armor[3],
            inventory.Armor[2],
            inventory.Armor[1],
            inventory.Armor[0],
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
        //list.RemoveAll(x => !x.Item.Present);
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
        if (data.Length > 0)
            foreach (var player in LoadedPlayers)
            {
                player.network.Send(new EntityEquipment()
                {
                    EntityID = EntityID,
                    equipmentArray = data
                });
            }
    }

    public void SendUpdateHealth()
    {
        network.Send(new UpdateHealth()
        {
            Health = Health / MaxHealth * 20,
            Food = 20,
            FoodSaturation = 0
        });
    }
    public float GetMaxHealth() => Player.baseMaxHealth;
    public void Attack(LivingEntity target)
    {
        if (!(SelectedItem is Sword sword))
        {
            target.Health -= Player.baseHandDamage;
            return;
        }
        target.Health -= RandomPlus.Range(sword.MinDamage, sword.MaxDamage + 1);
    }
    public void RespawnPlayer()
    {
        MaxHealth = GetMaxHealth();
        Health = MaxHealth;
        PlayerTitle.SetTitles(network, Chat.ColoredText($"&4Вы умерли"), 0, 5 * 20, 20);
        TeleportTo(world.SpawnPoint);
        //network.Send(new Respawn()
        //{
        //    Dimension = SupportedProtocol.allprotocols[protocolVersion].Dimension,
        //    Gamemode = (byte)Gamemode,
        //    PreviousGamemode = (byte)Gamemode,
        //    DimensionName = currentWorldName,
        //    HashedSeed = 0
        //});
    }
}
