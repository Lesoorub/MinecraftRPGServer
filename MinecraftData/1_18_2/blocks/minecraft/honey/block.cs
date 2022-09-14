using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.honey_block)]
    public class honey_block : IBlockData
    {
        public short DefaultStateID => 16078;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 14;
        public short DroppedItem => 593;
        public MinecraftMaterial Material => MinecraftMaterial.organic_product;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 16078,
                Properties = new byte[] {  },
                CollisionShape = 247,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
