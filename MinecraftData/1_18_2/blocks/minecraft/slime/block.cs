using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.slime_block)]
    public class slime_block : IBlockData
    {
        public short DefaultStateID => 7753;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 13;
        public short DroppedItem => 592;
        public MinecraftMaterial Material => MinecraftMaterial.organic_product;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 7753,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
