namespace MinecraftRPGServer.core.Configs
{
    public class WorldsConfig : Config<WorldsConfig>
    {
        public const string PATH = "worlds.json";

        public bool AllowBreakBlocks = true;
        public int MaxViewDistance = 8;
        public string WorldPath = @"World";
    }
}