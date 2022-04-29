using Newtonsoft.Json;
using System.IO;

public class ServerConfig
{
    public const string PATH = "cfg.json";

    //Status
    public string[] descriptions = new string[]
    {
        //"←→↑↓⛏🪓🏹🗡✂🛡🎣🔱⚗🧪♪♫♬☻♂🔥🌊☄☠☀☂☃☁☽☃™©®℗★☆■□♦♠♥♣♢♤♡♧¿¡∞⚐⚑✔✖✎♀♂⚓⛨⚀⚁⚂⚃⚄⚅≡±≥≤⌠⌡÷≈°∙√ⁿ²■⯪⯫Ɑ🛡✂🍖🪣🔔⏳⚑₠₡₢₣₤₥₦₩₫₭₮₰₱₲₳₵₶₷₸₹₺₻",
        "              &a🏹 &l&#FF4400H&#b74b24E&#b65149L&#92586dL&#6d5f92I&#4966b6U&#246cdbM &9🛡 &l&6MMORPG &c🗡&r                 " +
        "                         &#a6a6a6C&#a0a0a0l&#9b9b9bo&#959595s&#8f8f8fe&#898989d &#7e7e7ea&#787878l&#737373p&#6d6d6dh&#676767a &#5c5c5ct&#565656e&#505050s&#4b4b4bt",
    };

    //Chat
    public string ChatFormat = "{channel}&f{playername}: {message}";
    public string GlobalChannelName = "&e[G]";
    public string LocalChannelName = "&9[L]";
    public int LocalRange = 100;
    public int maxMessageSize = 100;
    public string PMFormat = "[{playername} -> {selfusername}]: {message}";
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
