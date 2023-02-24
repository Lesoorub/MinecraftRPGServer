using System;
using System.IO;
using Inventory;
using Newtonsoft.Json;

public class PlayerData
{
    public const string players_save_path = "playerdata";
    public static string save_path(Guid uuid) => Path.Combine(players_save_path, uuid.ToString() + ".json");
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
        string path = save_path(uuid);
        new DirectoryInfo(Path.Combine(server.config.world.WorldPath, players_save_path)).Create();
        if (File.Exists(path))
        {
            var text = File.ReadAllText(path);
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
                File.WriteAllText(path + ".wrong", JsonConvert.SerializeObject(json));
                File.Delete(path);
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

        new DirectoryInfo(players_save_path).Create();
        File.WriteAllText(save_path(player.PlayerUUID), JsonConvert.SerializeObject(this, jsonSerializerSettings));
    }
}