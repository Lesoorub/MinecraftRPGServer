using System.Collections.Generic;
using Packets.Play;
using System;

public class WorldLoaderController : IModule
{
    Player player;
    public List<v2i> loadedChunks = new List<v2i>();
    public void Init(Player player)
    {
        this.player = player;
        player.OnChunkChanged += Player_OnChunkChanged;
    }

    private void Player_OnChunkChanged(v2i lastchunk, v2i newchunk)
    {
        SendUpdateViewPosition();
        SendWorld();
    }
    public void Tick()
    {

    }
    public void SendWorld()
    {
        lock (loadedChunks)
        {
            int r = player.settings.ViewDistance + 1;
            var cpos = player.ChunkPos;
            void f(int x, int z)
            {
                var rpos = new v2i(x, z);
                if (loadedChunks.Contains(rpos))
                    return;
                loadedChunks.Add(rpos);
                var chunk = player.world.GetChunk(rpos);
                if (chunk == null) return;
                player.network.Send(chunk.BacketPacket);
            }
            for (int k = 0; k < r; k++)
                for (int x = -k; x <= k; x++)
                    for (int z = -k; z <= k; z++)
                    {
                        if (Math.Abs(x) != k && Math.Abs(z) != k) continue;
                        f(x + cpos.x, z + cpos.y);
                    }
            //Unload chunks
            foreach (var pos in loadedChunks)
            {
                if (Math.Abs(pos.x - cpos.x) > r ||
                    Math.Abs(pos.y - cpos.y) > r)
                    SendUnloadChunk(pos);
            }
            loadedChunks.RemoveAll(pos =>
                Math.Abs(pos.x - cpos.x) > r ||
                Math.Abs(pos.y - cpos.y) > r);
        }
    }
    public void SendUpdateViewPosition()
    {
        var cpos = player.ChunkPos;
        player.network.Send(new UpdateViewPosition()
        {
            ChunkX = cpos.x,
            ChunkZ = cpos.y,
        });
    }
    public void UnloadChunks()
    {
        lock (loadedChunks)
        {
            foreach (var pos in loadedChunks)
                SendUnloadChunk(pos);
            loadedChunks.Clear();
        }
    }
    public void SendUnloadChunk(v2i pos)
    {
        player.network.Send(new UnloadChunk()
        {
            ChunkX = pos.x,
            ChunkZ = pos.y,
        });
    }
}