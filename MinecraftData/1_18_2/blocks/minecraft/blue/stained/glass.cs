using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.blue_stained_glass)]
    public class blue_stained_glass : IBlockData
    {
        public short DefaultStateID => 4175;
        public float Hardness => 0.3f;
        public float ExplosionResistance => 0.3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 411;
        public MinecraftMaterial Material => MinecraftMaterial.glass;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4175,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
