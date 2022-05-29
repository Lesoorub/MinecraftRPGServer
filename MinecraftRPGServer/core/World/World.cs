using System.Collections.Generic;
using System.Linq;
public abstract class World
{
    public string publicName; 
    public v3f SpawnPoint;
    public float SpawnRotation;
    public EntityWorld entities = new EntityWorld();

    public virtual Chunk GetChunk(v2i cpos) => throw new System.NotImplementedException();
    public virtual BlockState GetBlock(v3i location) => throw new System.NotImplementedException();
    public virtual BlockState GetBlock(Position location) => throw new System.NotImplementedException();
    public virtual BlockState GetBlock(int x, int y, int z) => throw new System.NotImplementedException();
    public virtual bool SetBlock(Player player, int x, int y, int z, BlockState blockId) => throw new System.NotImplementedException();
    public virtual void Update() { }
}
