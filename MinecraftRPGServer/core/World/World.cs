using WorldSystemV2;

public abstract class World : IWorld, ICollisionProvider//, ILightWorld
{
    public const int MinSection = -4;
    public const int MaxSection = 19;
    public const int MinLightSection = -5;
    public const int MaxLughtSection = 20;

    public virtual string Path { get; set; }
    public virtual string PublicName { get; set; }
    public virtual v3f SpawnPoint { get; set; } = new v3f(0, 64, 0);
    public virtual v2f SpawnRotation { get; set; } = new v2f(0, 0);
    public virtual IChunkGenerator Generator { get; set; }

    public virtual WorldInfo Info { get; set; }

    public virtual EntityWorld EntityWorld { get; set; } = new EntityWorld();

    public virtual BlockState GetBlock(v3i location) => 
        throw new System.NotImplementedException();
    public virtual BlockState GetBlock(Position location) => 
        throw new System.NotImplementedException();
    public virtual BlockState GetBlock(int x, short y, int z) => 
        throw new System.NotImplementedException();
    public virtual bool SetBlock(Player player, int x, short y, int z, BlockState blockId) => 
        throw new System.NotImplementedException();
    public virtual void Update() { }
    public virtual void PrepairingToSpawnWorld(int radius) { }

    public virtual bool HasCollision(v3i position)
    {
        return GetBlock(position).haveCollision;
    }

    public virtual bool HasChunk(int x, int y) =>
        throw new System.NotImplementedException();

    public virtual IChunk GetChunk(int x, int y) =>
        throw new System.NotImplementedException();

    public virtual void Save(string path) =>
        throw new System.NotImplementedException();
}