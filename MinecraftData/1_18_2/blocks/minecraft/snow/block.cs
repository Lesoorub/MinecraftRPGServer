using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.snow_block)]
    public class snow_block : IBlockData
    {
        public short DefaultStateID => 3999;
        public state DefaultState => States[0];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => false;
        public byte SoundGroup => 9;
        public short DroppedItem => 253;
        public MinecraftMaterial Material => MinecraftMaterial.snow_block;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 3999,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
