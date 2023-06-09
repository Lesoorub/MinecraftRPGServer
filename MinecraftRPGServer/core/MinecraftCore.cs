using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MinecraftRPGServer;
using MinecraftRPGServer.core.Configs;
using MineServer;
using WorldSystemV2;

public sealed partial class MinecraftCore : MineServer.ConnectionsServer
{
    public ServerConfig config;

    public TabPlayerInfo tab;
    public Logger logger = new Logger();
    public Dispatcher dispatcher = new Dispatcher();
    public MinecraftCore(StartUpSettings settings) : base(settings.port)
    {
        var partTimer = new System.Diagnostics.Stopwatch();
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();

        Player.playerDataProvider = new FileSystemPlayerDataProvider(this);

        Dictionary<string, Action> init = new Dictionary<string, Action>()
        {
            { "Load configs by", () => {
                if (!settings.NoReadConfigs)
                    config = ServerConfig.Load();
                else
                    config = new ServerConfig();
            } },
            { "Load plugins by", () =>
            {
                PluginManager.LoadPlugins(this, config.PluginsFolder);
                if (PluginManager.plugins.Count > 0)
                    PluginManager.OnPreInit(this);
            } },
            { "Load custom items by", () => Inventory.Item.InitItems() },
            { "Load protocolPackets by", () => LoadPackets() },
            { "Load worlds by", () => LoadWorlds() },
            { "Load entities by", () => Entity.InitEntities() },
            { "Load commands by", () => Commands.Init() },
        };

        partTimer.Start();
        ////DEBUG
        //config = ServerConfig.Load();
        //for (int k = 0; k < 100; k++)
        //{
        //    partTimer.Restart();
        //    LoadWorlds();
        //    logger.Write($"{k} {((double)partTimer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
        //}
        ////
        foreach (var i in init)
        {
            partTimer.Restart();
            i.Value();
            logger.Write($"{i.Key} {((double)partTimer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
        }
        OnStart += MinecraftCore_OnStart;
        OnStop += MinecraftCore_OnStop;

        partTimer.Restart();
        if (PluginManager.plugins.Count > 0)
            PluginManager.OnPostInit(this);
        logger.Write($"Plugins post init {((double)partTimer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");

        timer.Stop();
        logger.Write($"Server loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }

    private void MinecraftCore_OnStart()
    {
        BeginServerLoop();
        //Init players tab
        tab = new TabPlayerInfo(this);
    }
    private void MinecraftCore_OnStop()
    {
        //current_world.Save(); TODO
        foreach (var player_pair in loginnedPlayers)
            player_pair.Value.data.Save(player_pair.Value);
    }

    public void ExecuteConsoleCommand(string text)
    {
        string[] sp = text.Split(' ');
        if (Commands.Execute(sp[0], this, null, sp.Skip(1)))
            return;
        switch (sp[0])
        {
            default:
                Console.WriteLine($"{sp[0]} is unknown command");
                break;
        }
    }


    protected override IClient OnClientConnect(Client client)
    {
        return new ConnectedClient(client.network, this);
    }
    protected override void OnClientDisconnect(Client client, DisconnectReason reason)
    {

    }


    public void BeginServerLoop()
    {
        async Task WaitTick(long lastProcessingTick)
        {
            if (lastProcessingTick == currentTick)
                await Task.Delay(Math.Max(50 - (int)(DateTime.Now - lastTickTime).TotalMilliseconds, 0));
            if (lastProcessingTick == currentTick)
            {
                while (lastProcessingTick == currentTick)
                    Thread.Sleep(5);
            }
        }
        //Server loop
        Task.Factory.StartNew(async () =>
        {
            while (isStarted)
            {
                dispatcher.DispatchAll();
                await Task.Delay(50);
                currentTick++;
                lastTickTime = DateTime.Now;
            }
        }, TaskCreationOptions.LongRunning);
        //Player loop
        Task.Factory.StartNew(async () =>
        {
            long lastProcessingTick = 0;
            while (isStarted)
            {
                await WaitTick(lastProcessingTick);
                foreach (var player_pair in loginnedPlayers)
                    player_pair.Value.PlayerUpdate();
                lastProcessingTick = currentTick;
            }
        }, TaskCreationOptions.LongRunning);
        //Entity loop
        Task.Factory.StartNew(async () =>
        {
            long lastProcessingTick = 0;
            while (isStarted)
            {
                await WaitTick(lastProcessingTick);
                //TODO OPTIMIZE THIS!
                foreach (var loaded_ent_pair in loginnedPlayers
                    .SelectMany(x => x.Value.view.entities).Distinct())
                {
                    var ent = loaded_ent_pair.Value.entity;

                    if (!ent.Velocity.Equals(new v3f(0, 0, 0)))
                        ent.Position += ent.Velocity;

                    if (!ent.isDestroyed)
                        ent.Tick(currentTick);
                }
                lastProcessingTick = currentTick;
            }
        }, TaskCreationOptions.LongRunning);
        //Plugins loop
        Task.Factory.StartNew(async () =>
        {
            long lastProcessingTick = 0;
            while (isStarted)
            {
                await WaitTick(lastProcessingTick);
                PluginManager.OnTick(this, currentTick);
                lastProcessingTick = currentTick;
            }
        }, TaskCreationOptions.LongRunning);
    }
}
//Players
public sealed partial class MinecraftCore : ConnectionsServer
{
    public delegate void LoginInArgs(Player player);
    public event LoginInArgs OnLoginIn;
    public delegate void LoginOutArgs(Player player);
    public event LoginOutArgs OnLogOut;

    public ConcurrentDictionary<string, Player> loginnedPlayers = new ConcurrentDictionary<string, Player>();
    public int maxPlayers = 99;
    public int online => loginnedPlayers.Count;
    public bool LoginIn(IClient client, string login, out Player player, out string reason)
    {
        player = null;
        if (loginnedPlayers.ContainsKey(login))
        {
            reason = "Already connected";
            return false;
        }

        var data = PlayerData.GetOrCreate(login);
        player = new Player(data, worlds[(string)data["WorldName"]]);

        player.network = client.network;
        if (config.OnlineMode)
        {
            var aes = new AesNetworkProvider((client as ConnectedClient).SharedSecret);
            player.network.OnSendData = aes.OnSendData;
            player.network.OnRecieveData = aes.OnRecieveData;
        }

        player.protocolVersion = client.protocolVersion;
        (client as ConnectedClient).EndRecievePackets();
        ChangeSubClient(client, player);
        player.BeginRecievePackets();
        player.network.OnDisconnected += player.OnDisconnected;

        if (!PluginManager.OnPlayerLoginIn(player, out reason))
            return false;

        loginnedPlayers.TryAdd(login, player);
        OnLoginIn?.Invoke(player);
        reason = null;
        return true;
    }
    public bool Logout(string login)
    {
        if (loginnedPlayers.TryRemove(login, out var player))
        {
            PluginManager.OnPlayerLoginOut(player);
            player.data.Save(player);
            OnLogOut?.Invoke(player);
            player.Destroy();
            player.Dispose();
            return true;
        }
        return false;
    }
    public Player FindByUsername(string username) =>
        Player.players.TryGetValue(username, out var player) ? player : null;
}
//World
public sealed partial class MinecraftCore : ConnectionsServer
{
    public IWorldsProvider worldsProvider = /*Default provider*/new AnvilWorldsProvider();
    public static ILightEngine LightEngine;
    public ConcurrentDictionary<string, World> worlds = new ConcurrentDictionary<string, World>();
    public string spawnWorldName = "overworld";
    public World spawnWorld => worlds[spawnWorldName];

    public long currentTick = 0;
    public DateTime lastTickTime;
    public const int TicksPerSecond = 20;

    public void LoadWorlds()
    {
        var world = worldsProvider.CreateOrLoad(config.world.WorldPath, spawnWorldName);
        worlds.TryAdd(spawnWorldName, world);
        logger.Write("Load area around spawn");

        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();
        world.PrepairingToSpawnWorld(config.world.MaxViewDistance);
        timer.Stop();
        logger.Write($"Complete for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }
}
//Packets
public sealed partial class MinecraftCore : ConnectionsServer
{
    public static int IndexFromPacketIdAndState(int packet_id, State state) => packet_id + (1 << ((int)state * 10));
    public void LoadPackets()
    {
        //Register all packet listeners
        foreach (var type in Tools.GetTypesWithAttribute<PacketListenerAttribute>())
        {
            var obj = (IPacketListener)Activator.CreateInstance(type);
            var attrs = type.GetCustomAttributes<PacketListenerAttribute>();
            foreach (var attr in attrs)
                Register(attr.packet_id, attr.state, obj);
        }
        foreach (var type in Tools.GetTypesWithAttribute<BoundToClientPackageAttribute>())
        {
            var attr = type.GetCustomAttribute<BoundToClientPackageAttribute>();
            var obj = (IPacket)Activator.CreateInstance(type);
            PackageRegistry.BoundToClient.Add(IndexFromPacketIdAndState(obj.package_id, attr.state), type);
        }
        foreach (var type in Tools.GetTypesWithAttribute<BoundToServerPackageAttribute>())
        {
            var attr = type.GetCustomAttribute<BoundToServerPackageAttribute>();
            var obj = (IPacket)Activator.CreateInstance(type);
            PackageRegistry.BoundToServer.Add(IndexFromPacketIdAndState(obj.package_id, attr.state), type);
        }
    }
    public void Register(int packetid, State state, IPacketListener obj)
    {
        obj.server = this;
        PackageRegistry.Register(packetid, state, obj);
    }
}
