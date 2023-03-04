using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class FileSystemPlayerDataProvider : IPlayerDataProvider
{
    RPGServer server;
    public const string players_dir_in_world = "playerdata";

    public static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        CheckAdditionalContent = true,
    };
    public FileSystemPlayerDataProvider(RPGServer server)
    {
        this.server = server;
    }

    public Task<PlayerData> GetOrCreatePlayerData(string loginname)
    {
        return Task.Run(() =>
        {
            var fi = PathToSave(Player.FromLoginName(loginname));
            if (fi.Exists)
            {
                var text = File.ReadAllText(fi.FullName);
                try
                {
                    return JsonConvert.DeserializeObject<PlayerData>(text, jsonSerializerSettings);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Can't read PlayerData! ... Replace and create new.");
                    var json = new
                    {
                        exception = ex,
                        wrongJson = text
                    };
                    File.WriteAllText(fi.FullName + ".wrong", JsonConvert.SerializeObject(json));
                    File.Delete(fi.FullName);
                    return new PlayerData(loginname, server);
                }
            }

            return new PlayerData(loginname, server);
        });
    }

    public Task SavePlayerData(string loginname, PlayerData data)
    {
        return Task.Run(() =>
        {
            File.WriteAllText(PathToSave(Player.FromLoginName(loginname)).FullName, JsonConvert.SerializeObject(data, jsonSerializerSettings));
        });
    }

    public FileInfo PathToSave(Guid player_uuid)
    {
        var fi = new FileInfo(Path.Combine(server.config.world.WorldPath, players_dir_in_world, player_uuid.ToString() + ".json"));
        fi.Directory.Create();
        return fi;
    }
}
