using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.iron_ore)]
    public class iron_ore : IBlockData
    {
        public short DefaultStateID => 71;
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 42;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 71,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
