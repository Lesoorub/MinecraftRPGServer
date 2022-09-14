using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.soul_sand)]
    public class soul_sand : IBlockData
    {
        public short DefaultStateID => 4069;
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 33;
        public short DroppedItem => 269;
        public MinecraftMaterial Material => MinecraftMaterial.aggregate;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4069,
                Properties = new byte[] {  },
                CollisionShape = 210,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
