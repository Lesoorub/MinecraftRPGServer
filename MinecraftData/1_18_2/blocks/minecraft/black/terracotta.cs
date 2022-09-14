using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.black_terracotta)]
    public class black_terracotta : IBlockData
    {
        public short DefaultStateID => 7080;
        public float Hardness => 1.25f;
        public float ExplosionResistance => 4.2f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 369;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 7080,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
