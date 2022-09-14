using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cobweb)]
    public class cobweb : IBlockData
    {
        public short DefaultStateID => 1397;
        public float Hardness => 4f;
        public float ExplosionResistance => 4f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 149;
        public MinecraftMaterial Material => MinecraftMaterial.cobweb;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1397,
                Properties = new byte[] {  },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
