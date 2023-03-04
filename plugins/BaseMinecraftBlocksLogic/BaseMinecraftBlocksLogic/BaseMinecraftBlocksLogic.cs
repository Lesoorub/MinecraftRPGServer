//[PluginConfig(typeof(BaseMinecraftBlocksLogicConfig))]
using System.Linq;
using Inventory;
using WorldSystemV2;
using ItemAttribute = Inventory.ItemAttribute;

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
public class BaseMinecraftBlocksLogicConfig : PluginConfig { }
namespace BaseLogic
{
    namespace Blocks
    {
        [BlockLogic(BlockNameID.grass)]
        public class Grass : BaseBlockLogic
        {
            public override void OnUpdate(Player player)
            {
                BreakBlockIfUnderItIsAir(world, x, y, z);
            }
            void BreakBlockIfUnderItIsAir(IWorld world, int x, short y, int z, DefaultBlockState defaultBlock = DefaultBlockState.air)
            {
                if (!GetUnderBlock(world, x, y, z, out var underBlock) ||
                    underBlock.isAir)
                    world.SetBlock(null, x, y, z, new BlockState((short)defaultBlock), SetBlockMode.BreakSoundAndAnimation);
            }
        }
        [BlockLogic(BlockNameID.tall_grass)]
        public class TallGrass : Grass { }
        [BlockLogic(BlockNameID.dead_bush)]
        public class DeadBush : Grass { }
        [BlockLogic(BlockNameID.vine)]
        public class Vine : BaseBlockLogic
        {
            public static short emptyState;
            static Vine()
            {
                if (GlobalPalette.GetStateIDByProperties(
                    BlockNameID.vine, 
                    new byte[] { 1, 1, 1, 1, 1 },
                    out var errorState))
                    emptyState = errorState.Id;
            }

            public override void OnUpdate(Player player)
            {
                var newState = FromWorld(world, x, y, z);
                if (newState.StateID == emptyState)
                {
                    world.SetBlock(player, x, y, z, BlockState.air, SetBlockMode.BreakSoundAndAnimation);
                }
                else
                {
                    if (newState.StateID != currentState.StateID)
                        world.SetBlock(player, x, y, z, newState);
                }
            }

            public static BlockState FromWorld(IWorld world, int x, short y, int z)
            {
                byte[] properties = new byte[]
                {
                    /*0*/(byte)(CanPlace(world.GetBlock(x + 1, y, z)) ? 0 : 1),
                    /*1*/(byte)(CanPlace(world.GetBlock(x, y, z - 1)) ? 0 : 1),
                    /*2*/(byte)(CanPlace(world.GetBlock(x, y, z + 1)) ? 0 : 1),
                    /*3*/1,
                    /*4*/(byte)(CanPlace(world.GetBlock(x - 1, y, z)) ? 0 : 1),
                };
                BlockState topBlock = BlockState.air;
                if (y != World.MaxBlockHeight)
                {
                    topBlock = world.GetBlock(x, (short)(y + 1), z);
                    properties[3] = (byte)(CanPlace(topBlock) ? 0 : 1);
                }
                GlobalPalette.GetStateIDByProperties(BlockNameID.vine, properties, out var newState);
                if (newState.Id == emptyState && topBlock.id == BlockNameID.vine)
                    newState.Id = topBlock.StateID;
                return new BlockState(newState.Id);
            }
            public static bool CanPlace(BlockState blockState)
            {
                var state = blockState.States.First(t => t.Id == blockState.StateID);
                if (blockState.id == BlockNameID.vine)
                    return false;
                return blockState.isSolid;
            }
        }

        [BlockLogic(BlockNameID.farmland)]
        public class Farmland : BaseBlockLogic
        {
            static BlockState Moistured0;
            static BlockState Moistured7;
            static Farmland()
            {
                if (GlobalPalette.GetStateIDByProperties(BlockNameID.farmland, new byte[] { 0 }, out var moistured))
                    Moistured0 = new BlockState(moistured.Id);
                if (GlobalPalette.GetStateIDByProperties(BlockNameID.farmland, new byte[] { 7 }, out var moistured))
                    Moistured7 = new BlockState(moistured.Id);
            }
            public override void OnRandomTick()
            {
                if (currentState.id == Moistured0.id)
                {
                    //Не намочен
                    if (FindWater())
                        world.SetBlock(null, x, y, z, Moistured7);
                }
                else
                {
                    //Намочен
                    if (!FindWater())
                        world.SetBlock(null, x, y, z, Moistured0);
                }
            }
            bool FindWater()
            {
                for (int rx = -4; rx <= 4; rx++)
                    for (int rz = -4; rz <= 4; rz++)
                    {
                        var block = world.GetBlock(x + rx, y, z + rz);
                        if (block.id == BlockNameID.water)
                            return true;
                    }
                return false;
            }
        }
    }
    namespace Items
    {
        [Item(ItemNameID.vine)]
        public class Vine : Item
        {
            public override bool OnTryingPlace(Player player, v3i Location, Direction Face, v3f cursor, out BlockState state)
            {
                state = Blocks.Vine.FromWorld(player.world, Location.x, (short)Location.y, Location.z);
                return state.StateID != Blocks.Vine.emptyState;
            }
        }
        [Item(ItemNameID.potato)]
        public class Potato : Item
        {
            public override bool OnTryingPlace(Player player, v3i Location, Direction Face, v3f cursor, out BlockState state)
            {
                var underBlock = player.world.GetBlock(Location + v3i.down);
                state = default;
                if (underBlock.id != BlockNameID.farmland)
                    return false;
                return base.OnTryingPlace(player, Location, Face, cursor, out state);
            }
        }
        [Item(ItemNameID.iron_hoe)]
        public class Hoe : Item, IUsable
        {
            
        }
    }
}