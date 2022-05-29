using System.Collections.Generic;
using System.Linq;
using MineServer;
using Packets.Play;
using System;
using System.Threading.Tasks;
using Inventory;

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
    public v3f ForwardDir => v3f.FromRotationInvertX(rotation);
    public v3f EyePosition => Position + new v3f(0, IsSneaking ? 1.5f : 1.62f, 0);
    private byte selectedSlot = 0;
    public byte SelectedSlot 
    { 
        get => selectedSlot;
        set
        {
            selectedSlot = Math.Max(Math.Min(value, (byte)9), (byte)0);
            SendEquipments();//Если выбраный слот изменен
        }
    }
    public EntityView view = new EntityView();

    public Weather currentWeather;
    //Modules
    public KeepAliveModule keepAlive = new KeepAliveModule();
    public WorldInteractController worldController = new WorldInteractController();
    public EntitiesController entitiesController = new EntitiesController();

    public PlayerSettings settings;
    public bool isInit => settings.ViewDistance != 0;
    public Guid PlayerUUID;
    //Inventory
    public InventoryOfPlayer inventory;
    public PlayerInventoryWindow inventoryWindow;
    public InventoryWindowWatcher inventoryWatcher;
    public AbstractWindow SecondWindow;
    public byte LastWindowID = 1;
    public override Item[] Armor => inventory.Armor.Select(x => x.item).ToArray();
    public override Item MainHand => inventory.hotbar[selectedSlot].item;
    public override Item OffHand => inventory.Offhand.item;
    public delegate void ItemTickArgs(Player player);
    public event ItemTickArgs OnPlayerTick;
    public int LastStateID = 1;

    public long PreviousRecievedMetadata = 0;
    public long LastAttackTime = 0;
    public const int AttackDelayTime = 200;
    public Dictionary<ItemID, long> Cooldowns = new Dictionary<ItemID, long>();

    protected override v3f HoloOffset => new v3f(0, -.2f, 0);

    public delegate void ConnectedArgs();
    public event ConnectedArgs OnConnected;

    public PlayerProtocol(World world) : base(world)
    {
        currentWeather = new Weather(this);
        OnConnected += PlayerProtocol_OnConnected;
        //Привязка функционала перемещения игрока на клиенте при изменении позиции чем-либо
        OnPositionChanged += PlayerProtocol_OnPositionChanged;
        OnHealthChanged += PlayerProtocol_OnHealthChanged;

        keepAlive.Init(this as Player);
        worldController.Init(this as Player);
        entitiesController.Init(this as Player);
    }

    private void PlayerProtocol_OnHealthChanged(LivingEntity sender, float newHealth, float oldHealth)
    {
        if (isInit)
        {
            if (newHealth < oldHealth)
                PlaySound(HurtSound, Position);
            Echo(Guid.Empty,
                ChatMessage_clientbound.PositionType.game_info,
                Chat.ColoredText($"&c{Health:N1}/{MaxHealth:N1}&f"));
            SendUpdateHealth();
        }
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
        inventoryWindow = new PlayerInventoryWindow(inventory);
        inventoryWatcher = new InventoryWindowWatcher(inventoryWindow);
        inventoryWatcher.OnChange += (window, args) =>
        {
            Console.WriteLine($"index={args.index} item={args.item?.GetType()}");
            if ((args.index >= 5 && args.index <= 8) ||
                (args.index >= 36 && args.index <= 45))
                SendEquipments();//Если инвентарь изменен
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
        rpgserver.tab?.SendPlayers(network);
        worldController.SendUpdateViewPosition();//25
        worldController.SendWorld();//26-27
        SendPlayerPositionAndLook();//30
        //Создать все сущности у игрока
        entitiesController.UpdateLoadedEntitiesLoad();//34+
        SendInventory();
        SendUpdateHealth();
        var player = this as Player;
        Player.players.TryAdd(player.data.username, player);

        //SendEquipments();
        //SendMetadataUpdate();

        inventory.Init(this as Player);
    }
    public void DropItem(ref Item item, byte count)
    {
        if (item == null || item.ItemCount < count) return;

        var clone = (Item)item.Clone();
        clone.ItemCount = count;
        Entities.Item.Spawn(world, clone, Position + new v3f(0, 1.5f, 0));
        item.ItemCount -= count;
        if (item.ItemCount <= 0)
            item = null;
    }
    public void DropItem(int index, byte count)
    {
        var item = inventoryWindow.GetItem(index);
        DropItem(ref item, count);
        inventoryWindow.SetSlot(index, item);
    }
    private void Rpgserver_OnLogOut(Player player)
    {
        rpgserver.OnLogOut -= Rpgserver_OnLogOut;

        Player.players.TryRemove(player.data.username, out var _);
        //Уничтожить себя у других игроков
        foreach (var entitypair in view.players)
        {
            if (entitypair.Value.entity.isInit)
                entitypair.Value.entity.entitiesController.UnloadEntity(EntityID);
        }
        OnPlayerTick?.Invoke(null);
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
        if (position.Equals(newposition)) return;
        var lastcpos = ChunkPos;
        LivingEntity_OnPositionChanged(position, newposition);
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
            position = newposition;
            SendPlayerPositionAndLook();//Передает новую позицию клиенту
            worldController.SendUpdateViewPosition();//Перемещает позицию подгружаемых чанков у клиента
            worldController.SendWorld();//Отправляет новый мир
            await Task.Delay(100);
            entitiesController.UpdateLoadedEntitiesLoad();//Обновить видимость энтити вокруг
            position = newposition;
            SendPlayerPositionAndLook();//Компенсирует падение игрока
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
    public void StopAllSounds()
    {
        network.Send(new StopSound()
        {
            Flags = 0
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
    public void SendCollectItem(int WhoIED, int ItemEID, int count)
    {
        network.Send(new CollectItem()
        {
            CollectedEntityID = ItemEID,
            CollectorEntityID = WhoIED,
            PickupItemCount = count
        });
    }


    protected void PlayerTick()
    {
        entitiesController.Tick();
        foreach(var item in GetEntityInRadius(Position, PlayerSettings.ItemPickUpRadius)
            .Select(x => x as Entities.Item)
            .Where(x => x != null))
        {
            if (!item.isDestroyed && item.PickUpReady)
            {
                var slot = (Item)item.meta["Item"];
                int count = slot.ItemCount;
                if (!inventory.AddItem(ref slot))
                    continue;
                if (slot != null && slot.Present)
                {
                    item.meta["Item"] = slot;
                    count -= slot.ItemCount;
                    continue;
                }
                item.Destroy();
                SendInventory();
                SendCollectItem(EntityID, item.EntityID, count);
                foreach (var other_player in view.players)
                    other_player.Value.entity.SendCollectItem(EntityID, item.EntityID, count);
                SendEquipments();//При поднятии предмета (игрок сам должен определять что инвентарь изменен и отправлять в другом месте)
            }
        }
        OnPlayerTick?.Invoke(this as Player);
    }
    public void SendInventory()
    {
        network.Send(new WindowItems()
        {
            WindowID = 0,
            slots = inventoryWindow.Slots,
            CarriedItem = inventory.CarriedItem.item,
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
    /// <summary>
    /// Обновить метаданные на своем клиенте и клиентах которые видят игрока
    /// </summary>
    public void SendMetadataUpdate()
    {
        var now = Time.Now();
        bool Send(long last, NetworkProvider net)
        {
            var changes = meta.GetMetadataChanges(last);
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

    public void PlayAnimation(EntityAnimation_clientbound.AnimationType animation)
    {
        foreach (var other_player in whoViewMe)
            SendPlayAnimation(animation, other_player.network);
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
        if (Time.Now() - LastAttackTime < AttackDelayTime) return;
        LastAttackTime = Time.Now();

        var sound = new Sound(SoundID.entity_player_attack_weak, Categories.PLAYERS);
        var damage = Player.baseHandDamage;
        if (MainHand is Inventory.Items.Sword sword)
        {
            damage = RandomPlus.Range(sword.MinDamage, sword.MaxDamage + 1);
            sound = sword.AttackSound;
        }

        if (damage == 0)
            PlayEntitySound(new Sound(SoundID.entity_player_attack_nodamage, Categories.PLAYERS));
        else
            PlayEntitySound(sound);
        if (target == null) return;
        ApplyDamageToTarget(target, damage);
    }
    protected override void Death()
    {
        PlaySound(DeathSound, Position);
        RespawnPlayer();
    }
    public void RespawnPlayer()
    {
        MaxHealth = GetMaxHealth();
        Health = MaxHealth;
        meta["Health"] = Health / MaxHealth * 20;
        meta["Pose"] = Pose.STANDING;
        ForceUpdateMetadata();
        PlayerTitle.SetTitles(network, Chat.ColoredText($"&4Вы умерли"), 0, 5 * 20, 20);
        Position = world.SpawnPoint.Clone();
    }
    public override void SendMaxHealth(NetworkProvider net) { }
    public void PlaySound(Sound sound, v3f position, float volume = 1, float pitch = 1)
    {
        network.Send(new SoundEffect()
        {
            SoundID = (int)sound.ID,
            x = (int)Math.Floor(position.x * 8),
            y = (int)Math.Floor(position.y * 8),
            z = (int)Math.Floor(position.z * 8),
            SoundCategory = sound.category,
            Volume = volume,
            Pitch = pitch,
        });
    }
    public void PlayEntitySound(Sound sound, float volume = 1, float pitch = 1)
    {
        network.Send(new EntitySoundEffect()
        {
            EntityID = EntityID,
            SoundID = (int)sound.ID,
            SoundCategory = sound.category,
            Volume = volume,
            Pitch = pitch,
        });
    }
    public void SendCooldown(ItemID ItemID, int ticks)
    {
        network.Send(new SetCooldown()
        {
            ItemID = (int)ItemID,
            CooldownTicks = ticks
        });
    }

    public void ApplyDamageToTarget(LivingEntity target, float damage)
    {
        target.Health -= damage;
        Hologram.Create(
                this as Player,
                target.Position + new v3f(
                    RandomPlus.Range(-.25f, .25f),
                    RandomPlus.Range(-.25f, .25f),
                    RandomPlus.Range(-.25f, .25f)
                ).Normalized + target.BoxCollider.y / 2 * v3f.up,
                $"&c-{damage:N1}", RPGServer.TicksPerSecond * 1);
    }
    public void OpenWindow(AbstractWindow window)
    {
        if (window.Type == -1) return;//Anyway ignore PlayerInventoryWindow
        window.Open(this as Player);
    }
    public void CloseWindow(int WindowID)
    {
        if (WindowID == 0) return;//Ignore PlayerInventoryWindow
        SecondWindow = null;
    }
}
