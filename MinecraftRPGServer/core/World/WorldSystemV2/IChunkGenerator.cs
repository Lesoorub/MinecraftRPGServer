namespace WorldSystemV2
{
    public interface IChunkGenerator
    {
        IChunk GenerateChunk(int x, int y);
    }
}