public interface IWorldsProvider
{
    World CreateOrLoad(string path, string publicName);
}