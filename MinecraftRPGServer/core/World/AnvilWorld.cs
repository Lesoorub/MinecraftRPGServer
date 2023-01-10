﻿using System;
using System.Threading.Tasks;
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
using NBT;
public class AnvilWorld : World
{
    public delegate void TimeChangedArgs(long newTime);
    public event TimeChangedArgs OnTimeChanged;
    public readonly string regionPATH = "region";
    public readonly string entitiesPATH = "entities";
    public string path;
    public ConcurrentDictionary<v2i, MCA> regions = new ConcurrentDictionary<v2i, MCA>();
    public WorldInfo info;
    Thread worldThread;
    public AnvilWorld(string path, string publicName)
    {
        this.publicName = publicName;
        this.path = path;
        new DirectoryInfo(path).Create();
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

    public bool LoadMCAFromPath(string path)
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
    public override Chunk GetChunk(v2i cpos)
    {
        int regx = cpos.x >> 5;
        int regz = cpos.y >> 5;
        var mca = GetRegion(regx, regz);
        return mca.GetChunk(cpos.x - regx * 32, cpos.y - regz * 32);
    }
    public void PrepairingToSpawnWorld(int radius)
    {
        int r = radius + 2;
        for (int x = -r; x < r; x++)
        {
            var cpos = new v2i(0, 0);
            for (int z = -r; z < r; z++)
            {
                GetChunk(new v2i(x + cpos.x, z + cpos.y));
            }
        };
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override BlockState GetBlock(v3i location) =>
        GetBlock(location.x, (short)location.y, location.z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override BlockState GetBlock(Position location) => 
        GetBlock(location.x, (short)location.y, location.z);

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
    public override BlockState GetBlock(int x, short y, int z)
    {
        GetChunkSectionFromCoords(x, y, z, out int csx, out int csy, out int csz);
        if (!GetChunkSection(csx, csy, csz, out Chunk chunk, out ChunkSection section)) 
            return BlockState.air;
        return section.GetBlock(Chunk.GetRelativeCoord(x), Chunk.GetRelativeCoord(y), Chunk.GetRelativeCoord(z));
    }
    public void SetTime(long newTime)
    {
        OnTimeChanged?.Invoke(newTime);
        info.Time = newTime;
    }
    public override void Update()
    {
        if (info == null) return;
        SetTime(info.Time + 1);
    }
    public override bool SetBlock(Player player, int x, short y, int z, BlockState blockId)
    {
        if (!MinecraftRPGServer.PluginManager.OnPlayerSetBlock(player, x, y, z, blockId.StateID))
            return false;
        var cpos = new v2i(x >> 4, z >> 4);
        var chunk = GetChunk(cpos);
        if (chunk == null)
            return false;
        var result = chunk.SetBlock((byte)((x - cpos.x * 16) % 16), (short)y, (byte)((z - cpos.y * 16) % 16), (short)blockId.StateID);
        foreach (var otherplayer in Player.WhoViewChunk(player.world, cpos))
            otherplayer.worldController.SendSetBlock(x, y, z, blockId);
        return result;
    }
}
