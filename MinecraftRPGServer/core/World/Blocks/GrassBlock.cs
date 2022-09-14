using System.Collections.Generic;
using System.Linq;

namespace Blocks
{
    [Block(DefaultBlockState.grass_block)]
    public class GrassBlock : IWorldBlock
    {
        public float hardness => 0.6f;
        public bool hasCollision => true;
    }

    namespace test
    {
        //[Block(DefaultBlockState.grass_block)]
        public class GrassBlock : MinecraftData._1_18_2.blocks.minecraft.grass_block
        {
            
        }
    }
}