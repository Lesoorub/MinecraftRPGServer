using System;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System.Text.Json.Serialization;

public class PlayerData
{
    public const string players_save_path = "World/Players";
    public static string save_path(Guid uuid) => Path.Combine(players_save_path, uuid.ToString() + ".json");
    public string username;
    public string loginname;
    public string WorldName;
    public byte Gamemode;
    public byte SelectedSlot;
    public v3f position;
    public v2f rotation;
    public float Health;
    public Item[] Inventory = new Item[46];
    public Item CarriendItem = new Item();


    private static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All,
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
        new DirectoryInfo(players_save_path).Create();
        if (File.Exists(path))
            return JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(path), jsonSerializerSettings);

        return new PlayerData(name, server);
    }
    /// <summary>
    /// Перенос данных из игрока в файл
    /// </summary>
    /// <param name="player"></param>
    public void Save(Player player)
    {
        WorldName = player.world.publicName;
        position = player.Position;
        rotation = player.Rotation;
        Inventory = player.inventory.slots;
        CarriendItem = player.inventory.CarriedItem;
        Health = player.Health;
        SelectedSlot = player.SelectedSlot;

        new DirectoryInfo(players_save_path).Create();
        File.WriteAllText(save_path(player.PlayerUUID), JsonConvert.SerializeObject(this, jsonSerializerSettings));
    }
}