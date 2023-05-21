using MongoDB.Bson;
using MongoDB.Driver;
using NBT;
using Newtonsoft.Json;
using System;
using System.Numerics;
using System.Threading;
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
            using (var source = new CancellationTokenSource(1000))
            {
                var ping = db.RunCommandAsync(
                    (Command<BsonDocument>)"{ping:1}",
                    cancellationToken: source.Token);
                ping.Wait();
            }
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
    public Task<NBTTag> GetOrCreatePlayerData(string loginname)
    {
        return Task.Run(() =>
        {
            var data = players.Find(filter: x => loginname.Equals(GetLoginName(x.nbt))).FirstOrDefault();
            if (data == null || string.IsNullOrEmpty(GetLoginName(data.nbt))) //create
            {
                data = new MongoPlayerData()
                {
                    nbt = new NBTTag(new PlayerData())
                };
                players.InsertOne(data);
            }
            return new NBTTag(data);
        });
    }

    public Task SavePlayerData(string loginname, NBTTag data)
    {
        return Task.Run(async () =>
        {
            await players.ReplaceOneAsync(
                x => loginname.Equals(GetLoginName(x.nbt)), 
                new MongoPlayerData()
                {
                    nbt = data,
                });
        });
    }
    
    string GetLoginName(NBTTag nbt)
    {
        if (!nbt.HasTag("loginname")) return null;
        return (string)nbt["loginname"];
    }
}

public class MongoPlayerData
{
    public ObjectId _id;
    public NBTTag nbt;
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