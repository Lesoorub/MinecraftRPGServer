using Newtonsoft.Json;
using System.IO;

public class ServerConfig
{
    public const string PATH = "cfg.json";

    //Status
    public string[] descriptions = new string[]
    {
        //"←→↑↓⛏🪓🏹🗡✂🛡🎣🔱⚗🧪♪♫♬☻♂🔥🌊☄☠☀☂☃☁☽☃™©®℗★☆■□♦♠♥♣♢♤♡♧¿¡∞⚐⚑✔✖✎♀♂⚓⛨⚀⚁⚂⚃⚄⚅≡±≥≤⌠⌡÷≈°∙√ⁿ²■⯪⯫Ɑ🛡✂🍖🪣🔔⏳⚑₠₡₢₣₤₥₦₩₫₭₮₰₱₲₳₵₶₷₸₹₺₻",
        $"             &a🏹 &grad(fc4300,246bd8)ARHELLIUM &9🛡 &l&6MMORPG &c🗡&r\n" +
        $"                   &grad(a6a6a6,4b4b4b)Closed alpha test",
    };

    //Chat
    public string ChatFormat = "{channel}&f{playername}&f: {message}";
    public string GlobalChannelName = "&e[G]";
    public string LocalChannelName = "&9[L]";
    public int LocalRange = 100;
    public int maxMessageSize = 100;
    public string PMFormat = "&6[{playername}&6 -> {selfusername}&6]: {message}&6";
    //Entities
    public float MaxDrawEntitiesRange = 32;
    public float MaxDrawEntitiesRangeThreshold = 8;
    //World
    public bool AllowBreakBlocks = false;
    public int MaxViewDistance = 8;
    public string WorldPath = @"C:\Users\Lesoorub\Desktop\Bukkit 1.18.2\world";

    public static ServerConfig Load()
    {
        if (File.Exists(PATH))
            return JsonConvert.DeserializeObject<ServerConfig>(File.ReadAllText(PATH));
        var cfg = new ServerConfig();
#if !DEBUG
        File.WriteAllText(PATH, JsonConvert.SerializeObject(cfg));
#endif
        return cfg;
    }
}
