using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.blue_concrete_powder)]
    public class blue_concrete_powder : IBlockData
    {
        public short DefaultStateID => 9715;
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 8;
        public short DroppedItem => 511;
        public MinecraftMaterial Material => MinecraftMaterial.aggregate;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9715,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}