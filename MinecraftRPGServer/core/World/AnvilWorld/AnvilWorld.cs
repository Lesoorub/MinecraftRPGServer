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

        foreach (var regPair in loader.regions)
            foreach (var chunkPair in regPair.Value.Chunks)
            {
                chunkPair.Value.Tick();
            }
    }
    public override bool SetBlock(
        Player player,
        int x,
        short y,
        int z,
        BlockState blockState,
        SetBlockMode mode = SetBlockMode.NoneSoundAndAnimation)
    {
        if (player != null && !PluginManager.OnPlayerSetBlock(player, x, y, z, blockState.StateID))
            return false;

        var beforeBlockState = GetBlock(x, y, z);

        var result = loader.SetBlock(x, y, z, blockState);

        SendSetBlockPackageAllPlayersAround();
        UpdateBlockAndNears();
        InvokingOnBlockPlacedAndDestroyed();

        return result;
        void InvokingOnBlockPlacedAndDestroyed()
        {
            if (!result) return;

            if (BlockLogicAttribute.TryGetLogic(beforeBlockState.id, out var logic))
            {
                logic.SetState(this, x, y, z, beforeBlockState);
                logic.OnBlockDestroyed(player);
            }
            if (BlockLogicAttribute.TryGetLogic(blockState.id, out logic))
            {
                logic.SetState(this, x, y, z, blockState);
                logic.OnBlockPlaced(player);
            }
        }
        void SendSetBlockPackageAllPlayersAround()
        {
            int cposX = MinecraftCoordinatesSystem.PosToChunk1D(x);
            int cposZ = MinecraftCoordinatesSystem.PosToChunk1D(z);
            //TODO 
            //Следующий цикл можно и нужно заменить на вызов ивента установки блока в чанке на который будет подписываться игрок при пригрузке его и отписываться при разгрузке
            foreach (var otherplayer in Player.WhoViewChunk(this, new v2i(cposX, cposZ)))
            {
                otherplayer.worldController.SendSetBlock(x, y, z, blockState);
                if (mode == SetBlockMode.BreakSoundAndAnimation)
                    SendBreakEffect(otherplayer);
            }
        }
        void UpdateBlockAndNears()
        {
            //tick seted block
            if (BlockLogicAttribute.TryGetLogic(blockState.id, out var logic))
            {
                logic.SetState(this, x, y, z, blockState);
                logic.OnUpdate(player);
            }
            //tick all blocks around
            for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                    for (int dz = -1; dz <= 1; dz++)
                    {
                        if (Math.Abs(dx) + Math.Abs(dy) + Math.Abs(dz) != 1)
                            continue;
                        int nx = x + dx,
                            nz = z + dz;
                        short ny = (short)Math.Min(Math.Max(y + dy, World.MinBlockHeight), World.MaxBlockHeight);
                        var block = GetBlock(nx, ny, nz);
                        if (block.isAir) continue;
                        if (BlockLogicAttribute.TryGetLogic(block.id, out logic))
                        {
                            logic.SetState(this, nx, ny, nz, block);
                            logic.OnUpdate(player);
                        }
                    }
        }
        void SendBreakEffect(Player otherplayer)
        {
            otherplayer.api.SendEffect(EffectID.Block_break, x, y, z, beforeBlockState.StateID, false);
        }
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
