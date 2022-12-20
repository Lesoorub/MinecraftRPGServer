using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.iron_block)]
    public class iron_block : IBlockData
    {
        public short DefaultStateID => 1484;
        public state DefaultState => States[0];
        public float Hardness => 5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 5;
        public short DroppedItem => 65;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1484,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
