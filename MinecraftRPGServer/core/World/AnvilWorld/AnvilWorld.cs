using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using AnvilWorldV2;
using MinecraftRPGServer;
using WorldSystemV2;

public class AnvilWorld : World
{
    public delegate void TimeChangedArgs(long newTime);
    public event TimeChangedArgs OnTimeChanged;
    Thread worldThread;
    AnvilWorldLoader loader;
    public AnvilWorld(string path, string publicName)
    {
        this.PublicName = publicName;
        this.Path = path;
        loader = new AnvilWorldLoader(path);

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override BlockState GetBlock(v3i location) =>
        GetBlock(location.x, (short)location.y, location.z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override BlockState GetBlock(Position location) =>
        GetBlock(location.x, (short)location.y, location.z);
    public override void PrepairingToSpawnWorld(int radius)
    {
        int r = radius + 2;
        for (int x = -r; x < r; x++)
        {
            var cpos = new v2i(0, 0);
            for (int z = -r; z < r; z++)
            {
                GetChunk(x + cpos.x, z + cpos.y);
            }
        };
    }


    public override BlockState GetBlock(int x, short y, int z)
    {
        return loader.GetBlock(x, y, z);
    }
    public void SetTime(long newTime)
    {
        OnTimeChanged?.Invoke(newTime);
        Info.Time = newTime;
    }
    public override void Update()
    {
        if (Info == null) return;
        SetTime(Info.Time + 1);
    }
    public override bool SetBlock(Player player, int x, short y, int z, BlockState blockState)
    {
        if (!PluginManager.OnPlayerSetBlock(player, x, y, z, blockState.StateID))
            return false;
        return loader.SetBlock(player, x, y, z, blockState);
    }
    public override void Save(string path)
    {
        var worldDir = new DirectoryInfo(path);
        //worldDir = new DirectoryInfo(System.IO.Path.Combine(worldDir.Parent.FullName, worldDir.Name + "2"));
        worldDir.Create();

        SaveRegions(worldDir);
    }

    public override bool HasChunk(int x, int z)
    {
        return loader.HasChunk(x, z);
    }
    public override IChunk GetChunk(int x, int z)
    {
        return loader.GetChunk(x, z);
    }

    private void SaveRegions(DirectoryInfo worldDir)
    {
        foreach (var pair in loader.regions)
        {
            var key = pair.Key;
            var mca = pair.Value;
            mca.SaveChunks();
            string fileName = $"r.{key.x}.{key.y}.mca";
            var regions = Directory.CreateDirectory(
                System.IO.Path.Combine(
                    worldDir.FullName, 
                    AnvilWorldLoader.regionPATH));
            File.WriteAllBytes(
                System.IO.Path.Combine(regions.FullName, fileName),
                mca.ToByteArray());
        }
    }
}
