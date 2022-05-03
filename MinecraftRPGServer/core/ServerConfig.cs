using Newtonsoft.Json;
using System.IO;

public class ServerConfig
{
    public const string PATH = "cfg.json";

    //Status
    public string[] descriptions = new string[]
    {
        //"←→↑↓⛏🪓🏹🗡✂🛡🎣🔱⚗🧪♪♫♬☻♂🔥🌊☄☠☀☂☃☁☽☃™©®℗★☆■□♦♠♥♣♢♤♡♧¿¡∞⚐⚑✔✖✎♀♂⚓⛨⚀⚁⚂⚃⚄⚅≡±≥≤⌠⌡÷≈°∙√ⁿ²■⯪⯫Ɑ🛡✂🍖🪣🔔⏳⚑₠₡₢₣₤₥₦₩₫₭₮₰₱₲₳₵₶₷₸₹₺₻",
        $"             &a🏹 {grad("ARHELLIUM", 0xfc4300, 0x246bd8)} &9🛡 &l&6MMORPG &c🗡&r\n" +
        $"                   {grad("Closed alpha test", 0xa6a6a6, 0x4b4b4b)}",
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

    static string grad(string text, int start_color, int end_color)
    {
        int ToColor(byte r, byte g, byte b) => r << 16 | g << 8 | b; 
        void FromColor(int color, out byte r, out byte g, out byte b)
        {
            r = (byte)((color >> 16) & 0xFF);
            g = (byte)((color >> 8) & 0xFF);
            b = (byte)(color & 0xFF);
        }
        System.Text.StringBuilder strb = new System.Text.StringBuilder();
        float lerp (float a, float b, float t) => a + (b - a) * t;
        FromColor(start_color, out var sr, out var sg, out var sb);
        FromColor(end_color, out var er, out var eg, out var eb);
        for (int k = 0; k < text.Length; k++)
        {
            float t = (float)k / text.Length;
            strb.Append($"&#{ToColor((byte)lerp(sr, er, t),(byte)lerp(sg, eg, t),(byte)lerp(sb, eb, t)):X}{text[k]}");
        }
        return strb.ToString();
    }

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
