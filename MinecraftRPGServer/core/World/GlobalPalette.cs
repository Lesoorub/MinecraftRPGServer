using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MineServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public static IBlockData GetBlockData(BlockNameID nameid) => BlocksData.blocks[nameid];
}