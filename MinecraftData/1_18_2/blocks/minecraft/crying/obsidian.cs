using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.crying_obsidian)]
    public class crying_obsidian : IBlockData
    {
        public short DefaultStateID => 16082;
        public float Hardness => 50f;
        public float ExplosionResistance => 1200f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 1065;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 16082,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
