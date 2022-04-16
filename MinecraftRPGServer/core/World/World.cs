using System;
using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MineServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class World
{
    public delegate void TimeChangedArgs(long newTime);
    public event TimeChangedArgs OnTimeChanged;
    public readonly string regionPATH = "region";
    public readonly string entitiesPATH = "entities";
    public string path;
    public ConcurrentDictionary<v2i, MCA> regions = new ConcurrentDictionary<v2i, MCA>();
    public NBTTag level;
    public long Seed;
    public long HashedSeed;
    public long Time { get; private set; } = 0;
    public long CycleTime = 24000;
    public v3f SpawnPoint;
    public v2f SpawnRotation = new v2f(0, 0);
    public ConcurrentDictionary<int, Entity> Entities = new ConcurrentDictionary<int, Entity>();
    public string publicName;

    Dictionary<v2i, Chunk> chunks = new Dictionary<v2i, Chunk>();
    Thread worldThread;
    public World(string path, string publicName)
    {
        this.publicName = publicName;
        this.path = path;
        if (!isValid(path))
            throw new Exception("Эта папка не является миром");

        new DirectoryInfo(Path.Combine(path, regionPATH)).Create();
        new DirectoryInfo(Path.Combine(path, entitiesPATH)).Create();

        level = new NBTTag(File.ReadAllBytes(Path.Combine(path, "level.dat")), true)["Data"];
        Seed = level["WorldGenSettings"]["seed"] as TAG_Long;
        SpawnPoint = new v3f(
            level["SpawnX"] as TAG_Int,
            level["SpawnY"] as TAG_Int,
            level["SpawnZ"] as TAG_Int);
        SpawnRotation = new v2f(level["SpawnAngle"] as TAG_Float, 0);
        using (SHA1Managed sha1 = new SHA1Managed())
            HashedSeed = BitConverter.ToInt64(sha1.ComputeHash(BitConverter.GetBytes(Seed).Take(8)), 0);

        worldThread = new Thread(() =>
        {
            while (true)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                Update();
                timer.Stop();
                Thread.Sleep(Math.Max(1000 / 20 - (int)timer.ElapsedMilliseconds, 0));
            }
        })
        {
            IsBackground = true
        };
        worldThread.Start();
    }

    public static bool isValid(string path)
    {
        if (!File.Exists(Path.Combine(path, "level.dat"))) return false;
        //if (!Directory.Exists(Path.Combine(path, "region"))) return false;
        //if (!Directory.Exists(Path.Combine(path, "entities"))) return false;

        return true;
    }
    public Chunk GetChunk(v2i cpos)
    {
        Chunk c;
        if (!chunks.ContainsKey(cpos))
        {
            c = LoadChunk(cpos);
            if (c == null) return null;
            chunks[cpos] = c;
        }
        else c = chunks[cpos];
        return c;
    }
    public Chunk LoadChunk(v2i cpos)
    {
        int regx = cpos.x >> 5;
        int regz = cpos.y >> 5;
        var mca = GetRegion(regx, regz);
        return mca.GetChunk(cpos.x - regx * 32, cpos.y - regz * 32);
    }
    public MCA GetRegion(int regx, int regz)
    {
        var key = new v2i(regx, regz);
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    int GetRelativeCoord(int x) => x & 0xF;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BlockState GetBlock(v3i location) =>
        GetBlock(location.x, location.y, location.z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BlockState GetBlock(Position location) => 
        GetBlock(location.x, location.y, location.z);
    public BlockState GetBlock(int x, int y, int z)
    {
        var cpos = new v2i(x >> 4, z >> 4);
        var chunk = GetChunk(cpos);
        if (chunk == null) return BlockState.air;
        int index = (y >> 4) + 4;
        if (index < 0) return BlockState.air;
        var section = chunk.sections[index];
        if (section == null) return BlockState.air;
        return section.GetBlock(GetRelativeCoord(x), GetRelativeCoord(y), GetRelativeCoord(z));
    }
    public void SetTime(long newTime)
    {
        OnTimeChanged?.Invoke(newTime);
        Time = newTime;
    }
    public void Update()
    {
        SetTime(Time + 1);
    }
}
