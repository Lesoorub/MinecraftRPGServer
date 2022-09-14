using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.honeycomb_block)]
    public class honeycomb_block : IBlockData
    {
        public short DefaultStateID => 16079;
        public float Hardness => 0.6f;
        public float ExplosionResistance => 0.6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 16;
        public short DroppedItem => 1063;
        public MinecraftMaterial Material => MinecraftMaterial.organic_product;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 16079,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
