public class AnvilWorldsProvider : IWorldsProvider
{
    public World CreateOrLoad(string path, string publicName)
    {
        return new AnvilWorld(path, publicName);
    }
}
