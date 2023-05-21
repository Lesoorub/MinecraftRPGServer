using Rust.Option;

namespace WorldSystemV2
{
    /// <summary>
    /// Абстрактный интерфейс мира
    /// </summary>
    public interface IWorld
    {
        string PublicName { get; set; }
        string Path { get; set; }
        v3f SpawnPoint { get; set; }
        v2f SpawnRotation { get; set; }
        IChunkGenerator Generator { get; set; }
        EntityWorld EntityWorld { get; set; }
        WorldInfo Info { get; }
        /// <summary>
        /// Объект предоставляющий данные чанков
        /// </summary>
        IWorldChunksProvider provider { get; }

        bool HasChunk(int x, int z);
        Option<IChunk> GetChunk(int x, int z);
        BlockState GetBlock(int x, short y, int z);
        bool SetBlock(Player player, int x, short y, int z, BlockState blockState, SetBlockMode mode = SetBlockMode.NoneSoundAndAnimation);
        void Update();
        void Save(string path);
    }
}