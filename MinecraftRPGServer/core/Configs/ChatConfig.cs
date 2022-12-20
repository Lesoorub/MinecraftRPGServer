namespace MinecraftRPGServer.core.Configs
{
    public class ChatConfig : Config<ChatConfig>
    {
        public const string PATH = "chat.json";

        public string ChatFormat = "{channel}&f{playername}&f: {message}";
        public string GlobalChannelName = "&e[G]";
        public string LocalChannelName = "&9[L]";
        public int LocalRange = 100;
        public int maxMessageSize = 100;
        public string PMFormat = "&6[{playername}&6 -> {selfusername}&6]: {message}&6";
    }
}