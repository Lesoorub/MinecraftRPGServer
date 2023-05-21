using System;
using Rust.Option;
using WorldSystemV2;

public abstract class World : IWorld, ICollisionProvider//, ILightWorld
{
    public const int MinSection = -4;
    public const int MaxSection = 19;
    public const int MinLightSection = -5;
    public const int MaxLightSection = 20;
    public const int MinBlockHeight = -64;
    public const int MaxBlockHeight = 319;

    public virtual string Path { get; set; }
    public virtual string PublicName { get; set; }
    public virtual v3f SpawnPoint { get; set; } = new v3f(0, 64, 0);
    public virtual v2f SpawnRotation { get; set; } = new v2f(0, 0);
    public virtual IChunkGenerator Generator { get; set; }
    public virtual WorldInfo Info { get; set; }
    public virtual EntityWorld EntityWorld { get; set; } = new EntityWorld();

    public abstract IWorldChunksProvider provider { get; }
    public abstract BlockState GetBlock(int x, short y, int z);
    public abstract bool SetBlock(Player player, int x, short y, int z, BlockState blockId, SetBlockMode mode = SetBlockMode.NoneSoundAndAnimation);
    public abstract bool HasChunk(int x, int y);
    public abstract Option<IChunk> GetChunk(int x, int y);
    public abstract void Update();
    public abstract void Save(string path);

    public virtual BlockState GetBlock(Position location) =>
        GetBlock(location.x, (short)location.y, location.z);
    public virtual BlockState GetBlock(v3i location) =>
        GetBlock(location.x, (short)location.y, location.z);
    [Obsolete]
    public virtual bool HasCollision(v3i position)
    {
        return GetBlock(position).haveCollision;
    }
    public virtual void PrepairingToSpawnWorld(int radius) { }
}