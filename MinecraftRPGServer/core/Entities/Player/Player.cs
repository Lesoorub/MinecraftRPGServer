using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using MineServer;
using Packets.Play;

public class Player : PlayerProtocol
{
    public static ConcurrentDictionary<string, Player> players = new ConcurrentDictionary<string, Player>();
    public override int EntityType => 111;
    public override v2f BoxCollider => new v2f(0.6f, 1.8f);
    public const string NameID = "minecraft:player";
    public override string ID => NameID;
    public override EntityMetadata meta { get; set; } = new PlayerMetadata();
    public PlayerData data;
    public const float baseMaxHealth = 100;
    public const float baseHandDamage = 1;

    /// <summary>
    /// Перенос значений из даты в игрока
    /// </summary>
    /// <param name="login"></param>
    /// <param name="server"></param>
    public Player(World world) : base(world) { }
    public Player(PlayerData data, RPGServer server) : base(server.worlds[data.WorldName])
    {
        this.data = data;
        PlayerUUID = FromLoginName(data.loginname);
        inventory = new Inventory.InventoryOfPlayer();
        data.inventory.UnloadTo(ref inventory);
        var lastcpos = ChunkPos;
        position = data.position;
        Entity_OnChunkChanged(lastcpos, ChunkPos);
        rotation = data.rotation;
        MaxHealth = GetMaxHealth();
        Health = data.Health;
        gamemode = (GamemodeType)data.Gamemode;
        SelectedSlot = data.SelectedSlot;
    }
    public void OnDisconnected(DisconnectReason reason)
    {
        rpgserver.Logout(data.loginname);
    }
    /// <summary>
    /// Called by the server every tick
    /// </summary>
    public void PlayerUpdate()
    {
        keepAlive.Tick();

        if (isInit)
            PlayerTick();
    }
    public static IEnumerable<Player> GetInWorld(World world) => players.Where(x => x.Value.world.Equals(world)).Select(x => x.Value);
    public static IEnumerable<Player> GetInWorldWithDistance(World world, v3f point, float radius) => players
        .Where(x => x.Value.world.Equals(world) && v3f.Distance(x.Value.Position, point) <= radius)
        .Select(x => x.Value);
    public static IEnumerable<Player> GetInWorldWithSqrDistance(World world, v3f point, float sqrradius) => players
        .Where(x => x.Value.world.Equals(world) && v3f.SqrDistance(x.Value.Position, point) <= sqrradius)
        .Select(x => x.Value);
}
