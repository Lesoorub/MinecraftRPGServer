using System;
using System.IO;
using System.Threading.Tasks;
using NBT;
using Newtonsoft.Json;

public class FileSystemPlayerDataProvider : IPlayerDataProvider
{
    MinecraftCore server;
    public const string players_dir_in_world = "playerdata";

    public FileSystemPlayerDataProvider(MinecraftCore server)
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
                var bytes = File.ReadAllBytes(fi.FullName);
                try
                {
                    return new NBTTag(bytes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Can't read PlayerData! ... Replace and create new.");
                    var json = new
                    {
                        exception = ex,
                        wrongJson = bytes
                    };
                    File.WriteAllBytes(fi.FullName + ".wrong", bytes);
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
            File.WriteAllBytes(PathToSave(
                Player.FromLoginName(loginname)).FullName, 
                data.Bytes
                );
        });
    }

    public FileInfo PathToSave(Guid player_uuid)
    {
        var fi = new FileInfo(Path.Combine(
            server.config.world.WorldPath,
            players_dir_in_world,
            player_uuid.ToString() + ".nbt"));
        fi.Directory.Create();
        return fi;
    }
}
