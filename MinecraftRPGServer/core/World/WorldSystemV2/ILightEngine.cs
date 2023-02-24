namespace WorldSystemV2
{
    public interface ILightEngine
    {
        void SetLightForChunk(IChunk target, IChunk[,] around);
    }
}