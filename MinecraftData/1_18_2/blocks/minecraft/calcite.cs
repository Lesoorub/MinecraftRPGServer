using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.calcite)]
    public class calcite : IBlockData
    {
        public short DefaultStateID => 17715;
        public state DefaultState => States[0];
        public float Hardness => 0.75f;
        public float ExplosionResistance => 0.75f;
        public bool IsTransparent => false;
        public byte SoundGroup => 55;
        public short DroppedItem => 11;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17715,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
