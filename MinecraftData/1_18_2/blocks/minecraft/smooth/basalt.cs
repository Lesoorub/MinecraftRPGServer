using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.smooth_basalt)]
    public class smooth_basalt : IBlockData
    {
        public short DefaultStateID => 20336;
        public float Hardness => 1.25f;
        public float ExplosionResistance => 4.2f;
        public bool IsTransparent => false;
        public byte SoundGroup => 35;
        public short DroppedItem => 273;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 20336,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
