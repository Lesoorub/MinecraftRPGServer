using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.quartz_block)]
    public class quartz_block : IBlockData
    {
        public short DefaultStateID => 6944;
        public float Hardness => 0.8f;
        public float ExplosionResistance => 0.8f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 350;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6944,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
