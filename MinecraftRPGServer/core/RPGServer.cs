using System;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using MineServer;
using System.Threading.Tasks;

public sealed partial class RPGServer : MineServer.MineServer
{
    public static Dictionary<State, Dictionary<int, List<IPacketListener>>> registered =
        new Dictionary<State, Dictionary<int, List<IPacketListener>>>();
    public static Dictionary<int, Type> BoundToClient = new Dictionary<int, Type>();
    public static Dictionary<int, Type> BoundToServer = new Dictionary<int, Type>();

    public ConcurrentDictionary<string, Player> loginnedPlayers = new ConcurrentDictionary<string, Player>();
    public int maxPlayers = 99;
    public int online => loginnedPlayers.Count;
    public ServerConfig config;
    public ConcurrentDictionary<string, World> worlds = new ConcurrentDictionary<string, World>();
    public string spawnWorldName = "overworld";
    public World spawnWorld => worlds[spawnWorldName];
    Thread ServerLoop;
    Thread PlayersLoop;
    Thread EntitiesLoop;
    public long currentTick = 0;
    public DateTime lastTickTime;
    public TabPlayerInfo tab;

    public RPGServer(ushort port) : base(port)
    {
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();

        //Init packets
        LoadPackets();
        //Logging errors
        errorLoger.OnMessage += (msg) => Console.WriteLine(msg);
        //Load config
        config = ServerConfig.Load();
        //Init blockEntities
        BlockEntity.Init(MinecraftRPGServer.Properties.Resources.block_entity_type_1_18_2);
        //Load world
        LoadWorlds();
        //Init Entities
        Entity.InitEntities();
        //Init items
        Inventory.Item.InitItems();
        //Init Commands
        Commands.Init();

        OnStart += RPGServer_OnStart;
        OnStop += RPGServer_OnStop;

        timer.Stop();
        Console.WriteLine($"Server loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }

    private void RPGServer_OnStart()
    {
        BeginServerLoop();
        //Init players tab
        tab = new TabPlayerInfo(this);
    }

    private void RPGServer_OnStop()
    {
        //current_world.Save(); TODO
        foreach (var player_pair in loginnedPlayers)
            player_pair.Value.data.Save(player_pair.Value);
    }

    public void Register(int packetid, State state, IPacketListener obj)
    {
        obj.server = this;
        if (!registered.ContainsKey(state))
        {
            registered.Add(state, new Dictionary<int, List<IPacketListener>>()
            {
                { packetid, new List<IPacketListener>() { obj } }
            });
            return;
        }
        if (!registered[state].ContainsKey(packetid))
        {
            registered[state].Add(packetid, new List<IPacketListener>() { obj });
            return;
        }
        registered[state][packetid].Add(obj);
    }
    public void ExecuteConsoleCommand(string text)
    {
        string[] sp = text.Split(' ');
        switch (sp[0])
        {
            default:
                Console.WriteLine($"{sp[0]} is unknown command");
                break;
        }
    }

    public static IEnumerable<Type> GetTypesWithAttribute<T>()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        foreach (Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(T), true).Length > 0)
            {
                yield return type;
            }
        }
    }

    public static int IndexFromPacketIdAndState(int packet_id, State state) => packet_id + (1 << ((int)state * 10));
    public void LoadPackets()
    {
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();
        //Register all packet listeners
        foreach (var type in GetTypesWithAttribute<PacketListenerAttribute>())
        {
            var obj = (IPacketListener)Activator.CreateInstance(type);
            var attrs = type.GetCustomAttributes<PacketListenerAttribute>();
            foreach (var attr in attrs)
                Register(attr.packet_id, attr.state, obj);
        }
        foreach (var type in GetTypesWithAttribute<BoundToClientPackageAttribute>())
        {
            var attr = type.GetCustomAttribute<BoundToClientPackageAttribute>();
            var obj = (IPacket)Activator.CreateInstance(type);
            BoundToClient.Add(IndexFromPacketIdAndState(obj.package_id, attr.state), type);
        }
        foreach (var type in GetTypesWithAttribute<BoundToServerPackageAttribute>())
        {
            var attr = type.GetCustomAttribute<BoundToServerPackageAttribute>();
            var obj = (IPacket)Activator.CreateInstance(type);
            BoundToServer.Add(IndexFromPacketIdAndState(obj.package_id, attr.state), type);
        }
        timer.Stop();
        Console.WriteLine($"Packets loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }
    public void LoadWorlds()
    {
        GlobalPalette.Init(MinecraftRPGServer.Properties.Resources.blocks);
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();
        worlds.TryAdd(spawnWorldName, new ReadOnlyWorld(config.WorldPath, spawnWorldName));
        timer.Stop();
        Console.WriteLine($"Worlds loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }
    protected override IClient OnClientConnect(Client client)
    {
        return new ConnectedClient(client.network, this);
    }
    protected override void OnClientDisconnect(Client client, DisconnectReason reason)
    {

    }

    public delegate void LoginInArgs(Player player);
    public event LoginInArgs OnLoginIn;
    public delegate void LoginOutArgs(Player player);
    public event LoginOutArgs OnLogOut;

    public bool LoginIn(IClient client, string login, out Player player)
    {
        player = null;
        if (loginnedPlayers.ContainsKey(login))
            return false;

        player = new Player(PlayerData.Get(Player.FromLoginName(login), login, this), this);

        player.network = client.network;
        player.protocolVersion = client.protocolVersion;
        (client as ConnectedClient).EndRecievePackets();
        ChangeSubClient(client, player);
        player.BeginRecievePackets();
        player.network.OnDisconnected += player.OnDisconnected;

        loginnedPlayers.TryAdd(login, player);
        OnLoginIn?.Invoke(player);
        return true;
    }
    public bool Logout(string login)
    {
        if (loginnedPlayers.TryRemove(login, out var player))
        {
            player.data.Save(player);
            OnLogOut?.Invoke(player);
            player.Destroy();
            return true;
        }
        return false;
    }
    public void BeginServerLoop()
    {
        void WaitTick(long lastProcessingTick)
        {
            if (lastProcessingTick == currentTick)
                Thread.Sleep(Math.Max(50 - (int)(DateTime.Now - lastTickTime).TotalMilliseconds, 0));
            if (lastProcessingTick == currentTick)
            {
                while (lastProcessingTick == currentTick)
                    Thread.Sleep(5);
            }
        }
        PlayersLoop = new Thread(() =>
        {
            long lastProcessingTick = 0;
            while (isStarted)
            {
                WaitTick(lastProcessingTick);
                foreach (var player_pair in loginnedPlayers)
                    player_pair.Value.PlayerUpdate();
                lastProcessingTick = currentTick;
            }
        });
        EntitiesLoop = new Thread(() =>
        {
            long lastProcessingTick = 0;
            while (isStarted)
            {
                WaitTick(lastProcessingTick);
                //TODO OPTIMIZE THIS!
                foreach (var loaded_ent_pair in loginnedPlayers
                    .SelectMany(x => x.Value.view.entities))
                {
                    var ent = loaded_ent_pair.Value.entity;

                    if (!ent.Velocity.Equals(new v3f(0, 0, 0)))
                        ent.Position += ent.Velocity;

                    if (!ent.isDestroyed)
                        ent.Tick(currentTick);
                }
                lastProcessingTick = currentTick;
            }
        });
        ServerLoop = new Thread(() =>
        {
            PlayersLoop.Start();
            EntitiesLoop.Start();
            while (isStarted)
            {
                Thread.Sleep(50);
                currentTick++;
                lastTickTime = DateTime.Now;
            }
        });

        ServerLoop.Start();
    }
    public Player FindByUsername(string username) => 
        Player.players.TryGetValue(username, out var player) ? player : null;
}
