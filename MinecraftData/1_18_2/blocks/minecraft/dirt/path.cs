using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dirt_path)]
    public class dirt_path : IBlockData
    {
        public short DefaultStateID => 9473;
        public float Hardness => 0.65f;
        public float ExplosionResistance => 0.65f;
        public bool IsTransparent => false;
        public byte SoundGroup => 2;
        public short DroppedItem => 393;
        public MinecraftMaterial Material => MinecraftMaterial.soil;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9473,
                Properties = new byte[] {  },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
