using MinecraftLightEngine;
using System.Collections.Generic;
using System.Linq;
public abstract class World : ICollisionProvider, ILightWorld
{
    public string publicName; 
    public v3f SpawnPoint = new v3f(0, 64, 0);
    public float SpawnRotation;
    public EntityWorld entities = new EntityWorld();

    public virtual Chunk GetChunk(v2i cpos) => throw new System.NotImplementedException();
    public virtual BlockState GetBlock(v3i location) => throw new System.NotImplementedException();
    public virtual BlockState GetBlock(Position location) => throw new System.NotImplementedException();
    public virtual BlockState GetBlock(int x, short y, int z) => throw new System.NotImplementedException();
    public virtual bool SetBlock(Player player, int x, short y, int z, BlockState blockId) => throw new System.NotImplementedException();
    public virtual void Update() { }

    public bool hasCollision(v3i position)
    {
        return GetBlock(position).haveCollision;
    }

    public byte[] GetSkyLightData(int chunk_x, int section_y, int chunk_z)
    {
        var cpos = new v2i(chunk_x >> 4, chunk_z >> 4);
        var chunk = GetChunk(cpos);
        if (chunk == null) return null;
        return chunk.GetSkyLightData(section_y);
    }

    public byte[] GetBlockLightData(int chunk_x, int section_y, int chunk_z)
    {
        var cpos = new v2i(chunk_x >> 4, chunk_z >> 4);
        var chunk = GetChunk(cpos);
        if (chunk == null) return null;
        return chunk.GetBlockLightData(section_y);
    }

    public void SetSkyLightData(int chunk_x, int section_y, int chunk_z, byte[] data)
    {
        var cpos = new v2i(chunk_x >> 4, chunk_z >> 4);
        var chunk = GetChunk(cpos);
        if (chunk == null) return;
        chunk.SetSkyLightData(section_y, data);
    }

    public void SetBlockLightData(int chunk_x, int section_y, int chunk_z, byte[] data)
    {
        var cpos = new v2i(chunk_x >> 4, chunk_z >> 4);
        var chunk = GetChunk(cpos);
        if (chunk == null) return;
        chunk.SetBlockLightData(section_y, data);
    }

    public byte GetBlockLightPower(int ax, short ay, int az)
    {
        if (GetBlock(ax, ay, az) == DefaultBlockState.dead_bush)
            return 15;
        return 0;
    }

    public bool IsLightTransparent(int ax, short ay, int az)
    {
        var block = GetBlock(ax, ay, az);
        var data = block.iBlockData;
        return data.IsTransparent;
        //GlobalPalette.GetBlockData(GlobalPalette.GetNameID(block.StateID));
        if (block == DefaultBlockState.air) return true;
        if (block == DefaultBlockState.dead_bush) return true;
        if (block == DefaultBlockState.grass) return true;
        if (block == DefaultBlockState.fern) return true;
        return false;
    }
}
