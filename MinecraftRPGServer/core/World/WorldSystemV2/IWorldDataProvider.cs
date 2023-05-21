using NBT;
using Rust.Option;

namespace WorldSystemV2
{
    /// <summary>
    /// Провайдер отвечающий за загрузку чанка
    /// </summary>
    public interface IWorldChunksProvider
    {
        /// <summary>
        /// Загружает чанк по его абсолютным координатам
        /// </summary>
        /// <param name="cx">Координата X</param>
        /// <param name="cz">Координата Z</param>
        /// <returns>Данные чанка</returns>
        Option<Chunk> GetChunk(int cx, int cz);
    }
}