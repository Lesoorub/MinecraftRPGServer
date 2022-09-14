using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.nether_quartz_ore)]
    public class nether_quartz_ore : IBlockData
    {
        public short DefaultStateID => 6933;
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 40;
        public short DroppedItem => 57;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6933,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
