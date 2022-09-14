using System;

namespace MinecraftData._1_18_2.blocks.minecraft
{
    public partial class BlockAttribute : Attribute
    {
        public BlockNameID nameID;
        public BlockAttribute(BlockNameID nameID) { this.nameID = nameID; }
    }
}