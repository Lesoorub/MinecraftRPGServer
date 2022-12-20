namespace MinecraftRPGServer.core.Configs
{
    public class EntitiesConfig : Config<EntitiesConfig>
    {
        public const string PATH = "entities.json";

        public float MaxDrawEntitiesRange = 32;
        public float MaxDrawEntitiesRangeThreshold = 8;
    }
}