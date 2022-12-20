using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cauldron)]
    public class cauldron : IBlockData
    {
        public short DefaultStateID => 5342;
        public state DefaultState => States[0];
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 870;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5342,
                Properties = new byte[] {  },
                CollisionShape = 370,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
