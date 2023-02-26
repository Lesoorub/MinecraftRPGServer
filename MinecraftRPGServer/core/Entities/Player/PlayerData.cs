using System;
using System.IO;
using Inventory;
using MinecraftRPGServer.core.Configs;
using Newtonsoft.Json;
using static Packets.Play.PlayerInfo;

public class PlayerData
{
    public const string players_dir_in_world = "playerdata";
    public string username;
    public string loginname;
    public string WorldName;
    public byte Gamemode;
    public byte SelectedSlot;
    public v3f position;
    public v2f rotation;
    public float Health;
    public PressedInventory inventory = new PressedInventory(new InventoryOfPlayer());


    public static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        CheckAdditionalContent = true,
    };
    public PlayerData() { }
    /// <summary>
    /// Данные нового игрока
    /// </summary>
    /// <param name="name"></param>
    /// <param name="server"></param>
    public PlayerData(string name, RPGServer server)
    {
        username = name;
        loginname = name;
        WorldName = server.spawnWorldName;
        position = server.spawnWorld.SpawnPoint;
        rotation = server.spawnWorld.SpawnRotation;
        Health = Player.baseMaxHealth;
    }
    /// <summary>
    /// Поиск и загрузка данных игрока
    /// </summary>
    /// <param name="uuid"></param>
    /// <param name="name"></param>
    /// <param name="server"></param>
    /// <returns></returns>
    public static PlayerData Get(Guid uuid, string name, RPGServer server)
    {
        var fi = PathToSave(server.config.world, uuid);
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
                return new PlayerData(name, server);
            }
        }

        return new PlayerData(name, server);
    }
    /// <summary>
    /// Перенос данных из игрока в файл
    /// </summary>
    /// <param name="player"></param>
    public void Save(Player player)
    {
        WorldName = player.world.PublicName;
        position = player.Position;
        rotation = player.Rotation;
        inventory = new PressedInventory(player.inventory);
        Health = player.Health;
        SelectedSlot = player.SelectedSlot;
        Gamemode = (byte)player.Gamemode;

        File.WriteAllText(PathToSave(player).FullName, JsonConvert.SerializeObject(this, jsonSerializerSettings));
    }

    public static FileInfo PathToSave(WorldsConfig config, Guid player_uuid)
    {
        var fi = new FileInfo(Path.Combine(config.WorldPath, players_dir_in_world, player_uuid.ToString() + ".json"));
        fi.Directory.Create();
        return fi;
    }
    public static FileInfo PathToSave(Player player)
    {
        return PathToSave((player.server as RPGServer).config.world, player.PlayerUUID);
    }
}