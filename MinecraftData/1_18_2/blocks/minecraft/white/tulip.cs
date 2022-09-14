using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.white_tulip)]
    public class white_tulip : IBlockData
    {
        public short DefaultStateID => 1475;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 2;
        public short DroppedItem => 180;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1475,
                Properties = new byte[] {  },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
