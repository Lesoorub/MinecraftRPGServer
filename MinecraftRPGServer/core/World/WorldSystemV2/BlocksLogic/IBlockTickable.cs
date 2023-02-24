using WorldSystemV2;

public interface IBlockTickable
{
    void OnUpdate(Player player, IWorld world, int x, short y, int z, BlockState currentState);
}
