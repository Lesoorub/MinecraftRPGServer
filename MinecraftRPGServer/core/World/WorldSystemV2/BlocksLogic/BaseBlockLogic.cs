using WorldSystemV2;
using static Packets.Play.PlayerInfo;

public abstract partial class BaseBlockLogic
{
    public IWorld world;
    public int x;
    public short y;
    public int z;
    public BlockState currentState;

    public void SetState(IWorld world, int x, short y, int z, BlockState currentState)
    {
        this.world = world;
        this.x = x;
        this.y = y;
        this.z = z;
        this.currentState = currentState;
    }

    public virtual void OnUpdate(Player player) { }
    public virtual void OnRandomTick() { }//is never invoking
    public virtual BlockState OnTryingPlaceBlock(Player player) => currentState;
    public virtual void OnBlockPlaced(Player player) { }
    public virtual void OnBlockDestroyed(Player player) { }


    public static bool GetUnderBlock(IWorld world, int x, short y, int z, out BlockState underBlock)
    {
        underBlock = BlockState.air;
        if (y == World.MinBlockHeight)
            return false;
        underBlock = world.GetBlock(x, (short)(y - 1), z);
        return true;
    }
}