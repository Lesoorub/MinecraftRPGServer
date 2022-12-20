namespace MinecraftRPGServer.core.Configs
{
    public class MotdConfig : Config<MotdConfig>
    {
        public const string PATH = "motd.json";

        public string faviconPath = "favicon.png";
        public string[] descriptions = new string[]
        {
        //"←→↑↓⛏🪓🏹🗡✂🛡🎣🔱⚗🧪♪♫♬☻♂🔥🌊☄☠☀☂☃☁☽☃™©®℗★☆■□♦♠♥♣♢♤♡♧¿¡∞⚐⚑✔✖✎♀♂⚓⛨⚀⚁⚂⚃⚄⚅≡±≥≤⌠⌡÷≈°∙√ⁿ²■⯪⯫Ɑ🛡✂🍖🪣🔔⏳⚑₠₡₢₣₤₥₦₩₫₭₮₰₱₲₳₵₶₷₸₹₺₻",
        $"             &a🏹 &grad(fc4300,246bd8)ARHELLIUM &9🛡 &l&6MMORPG &c🗡&r\n" +
        $"                   &grad(a6a6a6,4b4b4b)Closed alpha test",
        };
    }
}