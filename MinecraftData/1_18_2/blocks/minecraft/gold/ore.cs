using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.gold_ore)]
    public class gold_ore : IBlockData
    {
        public short DefaultStateID => 69;
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 46;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 69,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
