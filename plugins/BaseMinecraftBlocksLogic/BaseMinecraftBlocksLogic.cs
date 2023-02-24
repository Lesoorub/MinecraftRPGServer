//[PluginConfig(typeof(BaseMinecraftBlocksLogicConfig))]
using WorldSystemV2;
using static Packets.Play.PlayerInfo;

public class BaseMinecraftBlocksLogic : Plugin
{
    //BaseMinecraftBlocksLogicConfig cfg => (config as BaseMinecraftBlocksLogicConfig);
    public static RPGServer server;
    public override void OnPreInit(RPGServer server)
    {
        BaseMinecraftBlocksLogic.server = server;
    }

    public override void OnPlayerLoginInCompleted(Player player)
    {
        player.EchoSystemMessage("BaseMinecraftBlocksLogic enabled");
    }
}
//public class BaseMinecraftBlocksLogicConfig : PluginConfig { }
namespace BaseLogic
{
    public static class Tools
    {
        public static bool GetUnderBlock(IWorld world, int x, short y, int z, out BlockState underBlock)
        {
            underBlock = BlockState.air;
            if (y == World.MinBlockHeight)
                return false;
            underBlock = world.GetBlock(x, (short)(y - 1), z);
            return true;
        }
        public static void BreakBlockIfUnderItIsAir(Player player, IWorld world, int x, short y, int z, DefaultBlockState defaultBlock = DefaultBlockState.air)
        {
            if (!GetUnderBlock(world, x, y, z, out var underBlock) ||
                underBlock.isAir)
                world.SetBlock(player, x, y, z, new BlockState((short)defaultBlock), SetBlockMode.BreakSoundAndAnimation);
        }
    }

    [BlockLogic(BlockNameID.grass)]
    public class Grass : IBlockTickable
    {
        public void OnUpdate(Player player, IWorld world, int x, short y, int z, BlockState currentState)
        {
            Tools.BreakBlockIfUnderItIsAir(player, world, x, y, z);
        }
    }
    [BlockLogic(BlockNameID.tall_grass)]
    public class TallGrass : IBlockTickable
    {
        public void OnUpdate(Player player, IWorld world, int x, short y, int z, BlockState currentState)
        {
            Tools.BreakBlockIfUnderItIsAir(player, world, x, y, z);
        }
    }
    [BlockLogic(BlockNameID.dead_bush)]
    public class DeadBush : IBlockTickable
    {
        public void OnUpdate(Player player, IWorld world, int x, short y, int z, BlockState currentState)
        {
            Tools.BreakBlockIfUnderItIsAir(player, world, x, y, z);
        }
    }
}