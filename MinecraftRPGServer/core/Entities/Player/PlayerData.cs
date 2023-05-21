using System;
using System.Xml.Linq;
using Inventory;
using MinecraftRPGServer.core.Configs;
using NBT;
using static Packets.Play.PlayerInfo;

public class PlayerData
{
    public string username;
    public string loginname;
    public string WorldName;
    public byte Gamemode;
    public byte SelectedSlot;
    public v3f position;
    public v2f rotation;
    public float Health;
    public PressedInventory inventory = new PressedInventory(new InventoryOfPlayer());

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
    public static NBTTag GetOrCreate( string name)
    {
        return Player.playerDataProvider.GetOrCreatePlayerData(name)
            .GetAwaiter().GetResult();
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

        Player.playerDataProvider.SavePlayerData(loginname, new NBT.NBTTag(this)).GetAwaiter().GetResult();
    }
}
