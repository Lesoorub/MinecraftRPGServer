using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using NBT;

namespace AnvilWorldV2
{
    public class AnvilWorldLoader
    {
        public string path;
        public const string regionPATH = "region";
        public const string entitiesPATH = "entities";
        public WorldInfo info;
        public ConcurrentDictionary<v2i, MCA> regions = new ConcurrentDictionary<v2i, MCA>();
        public AnvilWorldLoader(string world_path)
        {
            this.path = world_path;
            new DirectoryInfo(path).Create();
            LoadLevelDataFromPath(path);
        }
        public bool LoadLevelDataFromPath(string path)
        {
            if (!isValid(path))
                return false;
            new DirectoryInfo(Path.Combine(path, regionPATH)).Create();
            new DirectoryInfo(Path.Combine(path, entitiesPATH)).Create();

            try
            {
                string levelPath = Path.Combine(path, "level.dat");
                if (!File.Exists(levelPath)) return false;
                var level = new NBTTag(File.ReadAllBytes(levelPath));
                if (!level.HasPath("Data")) return false;
                info = new AnvilWorldInfo(level);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool isValid(string path)
        {
            if (!File.Exists(Path.Combine(path, "level.dat"))) return false;
            //if (!Directory.Exists(Path.Combine(path, "region"))) return false;
            //if (!Directory.Exists(Path.Combine(path, "entities"))) return false;

            return true;
        }
        public MCA GetRegion(int regx, int regz)
        {
            var key = new v2i(regx, regz);
            lock (regions)
            {
                if (!regions.ContainsKey(key))
                {
                    string mcrPath = Path.Combine(path, regionPATH, $"r.{regx}.{regz}.mca");
                    if (File.Exists(mcrPath))
                    {
                        try
                        {
                            regions[key] = new MCA(File.ReadAllBytes(mcrPath));
                        }
                        catch
                        {
                            regions[key] = new MCA();
                        }
                    }
                    else regions[key] = new MCA();
                }
                return regions[key];
            }
        }
        public bool HasChunk(int x, int z)
        {
            int regx = x >> 5;
            int regz = z >> 5;
            var mca = GetRegion(regx, regz);
            return mca.HasChunk(x - regx * 32, z - regz * 32);
        }
        public Chunk GetChunk(int x, int z)
        {
            int regx = x >> 5;
            int regz = z >> 5;
            var mca = GetRegion(regx, regz);
            return mca.GetChunk(x - regx * 32, z - regz * 32);
        }
        public BlockState GetBlock(int x, short y, int z)
        {
            MinecraftCoordinatesSystem.GetChunkSectionFromCoords(x, y, z, out int csx, out int csy, out int csz);
            if (!GetChunkSection(csx, csy, csz, out Chunk chunk, out ChunkSection section))
                return BlockState.air;
            return section.GetBlock(Chunk.GetRelativeCoord(x), Chunk.GetRelativeCoord(y), Chunk.GetRelativeCoord(z));
        }
        public bool SetBlock(int x, short y, int z, BlockState blockState)
        {
            int cposX = MinecraftCoordinatesSystem.PosToChunk1D(x);
            int cposZ = MinecraftCoordinatesSystem.PosToChunk1D(z);
            var chunk = GetChunk(cposX, cposZ);
            if (chunk == null)
                return false;
            return chunk.SetBlock(
                (byte)((x - cposX * 16) % 16), y, 
                (byte)((z - cposZ * 16) % 16), 
                blockState.StateID);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetChunkSection(int csx, int csy, int csz, out Chunk chunk, out ChunkSection section)
        {
            section = null;
            chunk = GetChunk(csx, csz);
            if (chunk == null)
                return false;
            section = chunk.sections[csy];
            if (section == null)
                return false;
            return true;
        }
    }
}
