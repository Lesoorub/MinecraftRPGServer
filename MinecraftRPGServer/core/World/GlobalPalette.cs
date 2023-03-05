using System.Collections;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.InteropServices;
using MinecraftData._1_18_2.blocks.minecraft;
using BlocksData = MinecraftData._1_18_2.blocks.minecraft.BlockAttribute;

public class GlobalPalette
{
    public static int Length => BlocksData.blocks.Count;
    public static short[] GetStateIDs(BlockNameID nameid) =>
        BlocksData.blocks[nameid].States.Select(x => x.Id).ToArray();
    public static short[] GetStateIDs(short StateId) =>
        GetStateIDs(BlocksData.names[StateId]);
    public static DefaultBlockState GetDefaultStateID(BlockNameID nameid) =>
        (DefaultBlockState)BlocksData.blocks[nameid].DefaultStateID;
    public static DefaultBlockState GetDefaultStateID(short StateId) =>
        (DefaultBlockState)BlocksData.blocks[BlocksData.names[StateId]].DefaultStateID;
    public static BlockNameID GetNameID(short StateId) =>
        BlocksData.names[StateId];
    public static IBlockData GetBlockData(short StateId) =>
        BlocksData.blocks[BlocksData.names[StateId]];

    public static IBlockData GetBlockData(BlockNameID nameid)
    {
        return BlocksData.block2[(int)nameid];
    }

    public static bool GetStateIDByProperties(BlockNameID nameid, byte[] properties, out state state)
    {
        state = BlocksData.blocks[nameid].States.FirstOrDefault(x => x.Properties.SequenceEqual(properties));
        return state.Id != 0 && state.Properties != null;
    }
}