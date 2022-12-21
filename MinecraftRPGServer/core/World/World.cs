using MinecraftLightEngine;
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
        return GetBlock(ax, ay, az).DefaultState.Luminance;
    }

    public bool IsLightTransparent(int ax, short ay, int az)
    {
        return GetBlock(ax, ay, az).IsTransparent;
    }
}
