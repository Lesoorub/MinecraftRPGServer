using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Linq;

[PluginConfig(typeof(MongoDBPlayerSaverConfig))]
public class MongoDBPlayerSaver : Plugin
{
    MongoDBPlayerSaverConfig cfg => config as MongoDBPlayerSaverConfig;

    public override void OnPreInit(RPGServer server)
    {
        server.logger.Write("MongoDBPlayerSaver is loading...");
        MongoClient client = new MongoClient(cfg.MonogDBUrl);
        var db = client.GetDatabase(cfg.MongoDBdbName);

        if (Ping(db))
        {
            var collection = db.GetCollection<MongoPlayerData>(cfg.MongoDBCollectionName);
            Player.playerDataProvider = new MongoDBPlayerDataProvider(collection, server);
            server.logger.Write("MongoDBPlayerSaver loaded");
        }
        else
        {
            server.logger.Write("MongoDB is not available");
        }

    }

    bool Ping(IMongoDatabase db)
    {
        try
        {
            var ping = db.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
            ping.Wait();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
public class MongoDBPlayerSaverConfig : PluginConfig
{
    public string MongoDBusername = "root";
    public string MongoDBpassword = "password";
    public string MongoDBhost = "localhost";
    public int MongoDBPort = 27017;
    public string MongoDBdbName = "server";
    public string MongoDBCollectionName = "players";

    public string MonogDBUrl => $"mongodb://{MongoDBusername}:{MongoDBpassword}@{MongoDBhost}:{MongoDBPort}";
}

public class MongoDBPlayerDataProvider : IPlayerDataProvider
{
    IMongoCollection<MongoPlayerData> players;
    RPGServer server;
    public MongoDBPlayerDataProvider(IMongoCollection<MongoPlayerData> players, RPGServer server)
    {
        this.players = players;
        this.server = server;
    }
    public Task<PlayerData> GetOrCreatePlayerData(string loginname)
    {
        return Task.Run(() =>
        {
            var data = players.Find(filter: x => x.loginname.Equals(loginname)).FirstOrDefault();
            if (data == null || string.IsNullOrEmpty(data.loginname)) //create
            {
                data = new MongoPlayerData()
                {
                    username = loginname,
                    loginname = loginname,
                    WorldName = server.spawnWorldName,
                    position = server.spawnWorld.SpawnPoint,
                    rotation = server.spawnWorld.SpawnRotation,
                };
                players.InsertOne(data);
            }
            return data as PlayerData;
        });
    }

    public Task SavePlayerData(string loginname, PlayerData data)
    {
        return Task.Run(async () =>
        {
            await players.ReplaceOneAsync(x => x.loginname.Equals(loginname), data as MongoPlayerData);
        });
    }
}

public class MongoPlayerData : PlayerData
{
    public ObjectId _id;
}

//[ChatCommand]
//public class WGCommand : IChatCommand
//{
//    public void Register()
//    {
//        Commands.Register(new Node()
//        {
//            Name = "wg",
//            Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable
//        },
//        Execute);
//    }
//    void Execute(RPGServer server, Player player, string[] args)
//    {
//        player.EchoIntoChatFromServer("wg!");
//    }
//}