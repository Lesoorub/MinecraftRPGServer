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

public class ReadOnlyWorld : World
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
    

    Dictionary<v2i, Chunk> chunks = new Dictionary<v2i, Chunk>();
    Thread worldThread;
    public ReadOnlyWorld(string path, string publicName)
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
        SpawnRotation = level["SpawnAngle"] as TAG_Float;
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

        //PreLoad chunks
        LoadChunk(new v2i(0, 0));
    }

    public static bool isValid(string path)
    {
        if (!File.Exists(Path.Combine(path, "level.dat"))) return false;
        //if (!Directory.Exists(Path.Combine(path, "region"))) return false;
        //if (!Directory.Exists(Path.Combine(path, "entities"))) return false;

        return true;
    }
    public override Chunk GetChunk(v2i cpos)
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
    /// <summary>
    /// Load chunk in memory
    /// </summary>
    /// <param name="cpos">Absolute chunk position</param>
    /// <returns>Loaded chunk</returns>
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
    public override BlockState GetBlock(v3i location) =>
        GetBlock(location.x, location.y, location.z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override BlockState GetBlock(Position location) => 
        GetBlock(location.x, location.y, location.z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GetChunkSectionFromCoords(
        int x, int y, int z, 
        out int csx, out int csy, out int csz)
    {
        csx = x >> 4;
        csy = y >> 4;
        csz = z >> 4;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool GetChunkSection(int csx, int csy, int csz, out Chunk chunk, out ChunkSection section)
    {
        section = null;
        chunk = GetChunk(new v2i(csx, csz));
        if (chunk == null)
            return false;
        section = chunk.sections[csy];
        if (section == null)
            return false;
        return true;
    }
    public override BlockState GetBlock(int x, int y, int z)
    {
        GetChunkSectionFromCoords(x, y, z, out int csx, out int csy, out int csz);
        if (!GetChunkSection(csx, csy, csz, out Chunk chunk, out ChunkSection section)) 
            return BlockState.air;
        return section.GetBlock(Chunk.GetRelativeCoord(x), Chunk.GetRelativeCoord(y), Chunk.GetRelativeCoord(z));
    }
    public void SetTime(long newTime)
    {
        OnTimeChanged?.Invoke(newTime);
        Time = newTime;
    }
    public override void Update()
    {
        SetTime(Time + 1);
    }
    public override bool SetBlock(Player player, int x, int y, int z, BlockState blockId)
    {
        var cpos = new v2i(x >> 4, z >> 4);
        var chunk = GetChunk(cpos);
        if (chunk == null)
            chunks.Add(cpos, chunk = new Chunk(cpos));
        var result = chunk.SetBlock((byte)(x % 16), (short)y, (byte)(z % 16), (short)blockId.StateID);
        foreach (var otherplayer in Player.WhoViewChunk(player.world, cpos))
            otherplayer.worldController.SendSetBlock(x, y, z, blockId);
        return result;
    }
}
