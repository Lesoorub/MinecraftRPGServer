using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.green_concrete)]
    public class green_concrete : IBlockData
    {
        public short DefaultStateID => 9701;
        public float Hardness => 1.8f;
        public float ExplosionResistance => 1.8f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 497;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9701,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
