namespace WorldSystemV2
{
    public interface IWorld
    {
        string PublicName { get; set; }
        string Path { get; set; }
        v3f SpawnPoint { get; set; }
        v2f SpawnRotation { get; set; }
        IChunkGenerator Generator { get; set; }
        EntityWorld EntityWorld { get; set; }
        WorldInfo Info { get; }

        bool HasChunk(int x, int z);
        IChunk GetChunk(int x, int z);

        void Save(string path);
    }
}