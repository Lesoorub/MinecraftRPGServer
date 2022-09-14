using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.glass)]
    public class glass : IBlockData
    {
        public short DefaultStateID => 262;
        public float Hardness => 0.3f;
        public float ExplosionResistance => 0.3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 143;
        public MinecraftMaterial Material => MinecraftMaterial.glass;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 262,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
