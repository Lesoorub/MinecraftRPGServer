using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.netherite_block)]
    public class netherite_block : IBlockData
    {
        public short DefaultStateID => 16080;
        public float Hardness => 50f;
        public float ExplosionResistance => 1200f;
        public bool IsTransparent => false;
        public byte SoundGroup => 42;
        public short DroppedItem => 69;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 16080,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
