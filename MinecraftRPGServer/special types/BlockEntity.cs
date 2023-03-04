using WorldSystemV2;
public abstract class BlockEntity
{
    public IWorld world;
    public int x;
    public short y;
    public int z;
    public BlockEntityData data;
    public void SetState(IWorld world, int x, short y, int z, BlockEntityData data)
    {
        this.world = world;
        this.x = x;
        this.y = y;
        this.z = z;
        this.data = data;
    }
    public virtual void OnAttack() { }
    public virtual void OnOpen() { }
    public virtual void Tick() { }
}
