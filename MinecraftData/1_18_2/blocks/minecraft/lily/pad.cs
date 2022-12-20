using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.lily_pad)]
    public class lily_pad : IBlockData
    {
        public short DefaultStateID => 5215;
        public state DefaultState => States[0];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 3;
        public short DroppedItem => 304;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5215,
                Properties = new byte[] {  },
                CollisionShape = 366,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
