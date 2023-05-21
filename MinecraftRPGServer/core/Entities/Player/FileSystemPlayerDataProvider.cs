using System;
using System.IO;
using System.Threading.Tasks;
using NBT;
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

    public Task<NBTTag> GetOrCreatePlayerData(string loginname)
    {
        return Task.Run(() =>
        {
            var fi = PathToSave(Player.FromLoginName(loginname));
            if (fi.Exists)
            {
                var text = File.ReadAllText(fi.FullName);
                try
                {
                    return new NBTTag(JsonConvert.DeserializeObject<PlayerData>(text, jsonSerializerSettings));
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
                    return new NBTTag(new PlayerData(loginname, server));
                }
            }

            return new NBTTag(new PlayerData(loginname, server));
        });
    }

    public Task SavePlayerData(string loginname, NBTTag data)
    {
        return Task.Run(() =>
        {
            File.WriteAllText(PathToSave(
                Player.FromLoginName(loginname)).FullName, 
                JsonConvert.SerializeObject(
                    data.ToObject<PlayerData>(), 
                jsonSerializerSettings));
        });
    }

    public FileInfo PathToSave(Guid player_uuid)
    {
        var fi = new FileInfo(Path.Combine(server.config.world.WorldPath, players_dir_in_world, player_uuid.ToString() + ".json"));
        fi.Directory.Create();
        return fi;
    }
}
