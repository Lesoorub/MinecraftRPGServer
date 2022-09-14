using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.enchanting_table)]
    public class enchanting_table : IBlockData
    {
        public short DefaultStateID => 5333;
        public float Hardness => 5f;
        public float ExplosionResistance => 1200f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 310;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5333,
                Properties = new byte[] {  },
                CollisionShape = 13,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
