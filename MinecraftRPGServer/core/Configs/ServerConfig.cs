using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace MinecraftRPGServer.core.Configs
{
    public class ServerConfig : Config<ServerConfig>
    {
        public const string PATH = "config.json";

        public bool OnlineMode = false;
        public string PluginsFolder = "plugins";
        public string ConfigsFolder = "configs";

        [JsonIgnore]
        public MotdConfig motd = new MotdConfig();
        [JsonIgnore]
        public ChatConfig chat = new ChatConfig();
        [JsonIgnore]
        public EntitiesConfig entities = new EntitiesConfig();
        [JsonIgnore]
        public WorldsConfig world = new WorldsConfig();

        public static ServerConfig Load()
        {
            var cfg = Load(PATH);
            CreateDirIfNotExists(cfg.PluginsFolder);
            CreateDirIfNotExists(cfg.ConfigsFolder);

            cfg.motd = MotdConfig.Load(Path.Combine(cfg.ConfigsFolder, MotdConfig.PATH));
            cfg.chat = ChatConfig.Load(Path.Combine(cfg.ConfigsFolder, ChatConfig.PATH));
            cfg.entities = EntitiesConfig.Load(Path.Combine(cfg.ConfigsFolder, EntitiesConfig.PATH));
            cfg.world = WorldsConfig.Load(Path.Combine(cfg.ConfigsFolder, WorldsConfig.PATH));

            return cfg;
        }

        private static void CreateDirIfNotExists(string dirPath)
        {
            new DirectoryInfo(dirPath).Create();
        }
    }
}