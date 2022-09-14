using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.flower_pot)]
    public class flower_pot : IBlockData
    {
        public short DefaultStateID => 6511;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 946;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6511,
                Properties = new byte[] {  },
                CollisionShape = 40,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
