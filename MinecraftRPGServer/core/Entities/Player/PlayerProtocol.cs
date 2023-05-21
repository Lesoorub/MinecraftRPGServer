using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Inventory;
using MineServer;
using Packets.Play;

/// <summary>
/// Протокол игрока.
/// Класс изначально был предназначен для хранения
/// методов игрока, вскоре класс будет упразнен
/// </summary>
public class PlayerProtocol : 
    LivingEntity, 
    IClient,
    IEntityProtocol
{
    #region Fields
    public NetworkProvider network { get; set; }
    public MineServer.MineServer server { get; set; }
    public RPGServer rpgserver { get => server as RPGServer; }
    public int protocolVersion { get; set; }

    protected GamemodeType gamemode = GamemodeType.Survival;
    protected v2f rotation = new v2f(0, 0);
    public GamemodeType Gamemode { get => gamemode; set { gamemode = value; api.SendChangeGamemode(value); } }
    public override v2f Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            api.SendPlayerPositionAndLook();
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
            api.SendMetadataUpdate();
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

            api.SendMetadataUpdate();
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
    public PlayerAPI api;

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
    public Dictionary<ItemNameID, long> Cooldowns = new Dictionary<ItemNameID, long>();

    protected override v3f HoloOffset => new v3f(0, -.2f, 0);
    
    #endregion

    #region Events
    public delegate void ConnectedArgs();
    public event ConnectedArgs OnConnected;
    #endregion

    #region Constructors
    public PlayerProtocol(World world) : base(world)
    {
        currentWeather = new Weather(this as Player);
        OnConnected += PlayerProtocol_OnConnected;
        //Привязка функционала перемещения игрока на клиенте при изменении позиции чем-либо
        OnPositionChanged += PlayerProtocol_OnPositionChanged;
        OnHealthChanged += PlayerProtocol_OnHealthChanged;

        api = new PlayerAPI(this as Player);
        keepAlive.Init(this as Player);
        worldController.Init(this as Player);
        entitiesController.Init(this as Player);
    }

    #endregion

    #region Event handlers
    private void PlayerProtocol_OnHealthChanged(LivingEntity sender, float newHealth, float oldHealth)
    {
        if (isInit)
        {
            if (newHealth < oldHealth)
                api.PlaySound(HurtSound, Position);
            api.Echo(Guid.Empty,
                ChatMessage_clientbound.PositionType.game_info,
                Chat.ColoredText($"&c{Health:N1}/{MaxHealth:N1}&f"));
            api.SendUpdateHealth();
        }
    }
    private void PlayerProtocol_OnPositionChanged(v3f lastposition, v3f newposition)
    {
        if (v3f.Distance(lastposition, newposition) < 8)
        {
            //Это не телепортация
            api.SendPlayerPositionAndLook();//Отправить клиенту его текущую позицию и вращение
            entitiesController.UpdateLoadedEntitiesLoad();//Обновить видимость энтити вокруг
        }
        else
        {
            //Это телепортация
            TeleportTo(newposition.Clone());
        }
    }
    private void PlayerProtocol_OnConnected()
    {
        rpgserver.OnLogOut += Rpgserver_OnLogOut;
        inventoryWindow = new PlayerInventoryWindow(inventory);
        inventoryWatcher = new InventoryWindowWatcher(inventoryWindow);
        inventoryWatcher.OnChange += (window, args) =>
        {
            Console.WriteLine($"index={args.index} item={args.item?.GetType()}");
            if ((args.index >= 5 && args.index <= 8) ||//armor or
                (args.index >= 36 && args.index <= 45))//hot bar
                SendEquipments();//Если инвентарь изменен
        };
        api.SendHeldItemChanged();//16
        network.Send(new Tags()
        {
            tags = SupportedProtocol.allprotocols[protocolVersion].Tags
        });//18
        network.Send(new DeclareCommands()
        {
            data = Commands.DeclareCommands
        });//20
        //Создать все сущности у игрока
        entitiesController.UpdateLoadedEntitiesLoad();//34+
        api.SendInventory();
        api.SendUpdateHealth();
        api.SendPlayerPositionAndLook();//22
        rpgserver.tab?.SendPlayers(network);
        worldController.SendUpdateViewPosition();//25
        worldController.SendWorld();//26-27
        api.SendPlayerPositionAndLook();//30
        var player = this as Player;
        Player.players.TryAdd(player.data.username, player);

        //SendEquipments();
        //SendMetadataUpdate();

        inventory.Init(this as Player);
        MinecraftRPGServer.PluginManager.OnPlayerLoginInCompleted(this as Player);
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

    #endregion

    #region Methods
    public void OnPlayerTryPlaceBlock(v3i Location, Direction Face, bool isMainHand, v3f cursor)
    {
        v3i pos = Location;

        var placedOn = world.GetBlock(Location);

        if (!Tags_1_18_2.blocks.replaceable_plants_names.Contains(placedOn.id.ToString()))
        {
            pos += DirToV3f(Face);
        }

        //if (placePacket.CursorPositionX == 1 || placePacket.CursorPositionX == 0 ||
        //    placePacket.CursorPositionY == 1 || placePacket.CursorPositionY == 0 ||
        //    placePacket.CursorPositionZ == 1 || placePacket.CursorPositionZ == 0)
        if (!rpgserver.config.world.AllowBreakBlocks)
        {
            network.Send(new BlockChange()
            {
                BlockID = new VarInt(world.GetBlock(pos).StateID),
                Location = new Position(pos),
            });
            return;
        }


        if (placedOn.StateID == (short)DefaultBlockState.air)//Запрет ставить блок на воздух
            return;

        Item item;

        //Определяем какой предмет в руке
        if (isMainHand)
            item = MainHand;
        else
            item = OffHand;

        if (item == null || !item.OnTryingPlace(
            this as Player, 
            pos,
            Face, 
            cursor,
            out var state))//Если предмета в руке нет - игнор
        {
            return;
        }
        //Если предмет можно поставить в данную позицию

        if (state.StateID != 0 && 
            !world.SetBlock(this as Player, pos.x, (short)pos.y, pos.z, state))
        {
            network.Send(new BlockChange()
            {
                BlockID = new VarInt(world.GetBlock(pos).StateID),
                Location = new Position(pos),
            });
            return;
        }

        return;

        v3i DirToV3f(Direction face)
        {
            switch (face)
            {
                case Direction.East: return v3i.right;
                case Direction.West: return v3i.left;
                case Direction.South: return v3i.forward;
                case Direction.North: return v3i.back;
                case Direction.Top: return v3i.up;
                case Direction.Bottom: return v3i.down;
            }
            return v3i.zero;
        }
    }

    public void InvokeOnConnected() => OnConnected?.Invoke();
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

    public static Guid FromLoginName(string login) => new Guid(login.GetSha1().Take(16));

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
            api.SendPlayerPositionAndLook();//Передает новую позицию клиенту
            worldController.SendUpdateViewPosition();//Перемещает позицию подгружаемых чанков у клиента
            worldController.SendWorld();//Отправляет новый мир
            await Task.Delay(100);
            entitiesController.UpdateLoadedEntitiesLoad();//Обновить видимость энтити вокруг
            position = newposition;
            api.SendPlayerPositionAndLook();//Компенсирует падение игрока
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
            if (PackageRegistry.registered.TryGetValue(State.Play, out var dict) &&
                dict.TryGetValue(mpacket.packet_id, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.OnPacketRecieved(this,
                        (IPacket)PacketListener.Parse(
                            mpacket,
                            PackageRegistry.BoundToServer[
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

    public void EchoIntoChatFromServer(string message) =>
        api.Echo(Guid.Empty, ChatMessage_clientbound.PositionType.chat, Chat.ColoredText(message));
    public void EchoIntoChat(string message, Guid senderPlayerUUID) =>
        api.Echo(senderPlayerUUID, ChatMessage_clientbound.PositionType.chat, Chat.ColoredText(message));
    public void EchoSystemMessage(string msg) =>
        api.Echo(Guid.Empty, ChatMessage_clientbound.PositionType.system_message, Chat.ColoredText(msg));

    protected void PlayerTick()
    {
        entitiesController.Tick();
        foreach (var item in GetEntityInRadius(Position, PlayerSettings.ItemPickUpRadius)
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
                api.SendInventory();
                api.SendCollectItem(EntityID, item.EntityID, count);
                foreach (var other_player in view.players)
                    other_player.Value.entity.api.SendCollectItem(EntityID, item.EntityID, count);
                SendEquipments();//При поднятии предмета (игрок сам должен определять что инвентарь изменен и отправлять в другом месте)
            }
        }
        OnPlayerTick?.Invoke(this as Player);
    }

    public void SetFire(bool onFire)
    {
        if (onFire)
            meta.SetFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsOnFire);
        else
            meta.RemoveFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsOnFire);

        api.SendMetadataUpdate();
    }


    public void PlayAnimation(EntityAnimation_clientbound.AnimationType animation)
    {
        foreach (var other_player in whoViewMe)
            SendPlayAnimation(animation, other_player.network);
    }
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
            api.PlayEntitySound(new Sound(SoundID.entity_player_attack_nodamage, Categories.PLAYERS));
        else
            api.PlayEntitySound(sound);
        if (target == null) return;
        ApplyDamageToTarget(target, damage);
    }
    protected override void Death()
    {
        api.PlaySound(DeathSound, Position);
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
    #endregion
}
