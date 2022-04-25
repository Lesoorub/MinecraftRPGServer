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
        int r = player.settings.ViewDistance;
        var cpos = player.ChunkPos;
        for (int x = -r + 1; x < r; x++)
            for (int y = -r + 1; y < r; y++)
            {
                var rpos = new v2i(x + cpos.x, y + cpos.y);
                if (loadedChunks.Contains(rpos))
                    continue;
                loadedChunks.Add(rpos);
                var chunk = player.world.GetChunk(rpos);
                if (chunk == null) continue;
                player.network.Send(chunk.BacketPacket);
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
        foreach (var pos in loadedChunks)
            SendUnloadChunk(pos);
        loadedChunks.Clear();
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