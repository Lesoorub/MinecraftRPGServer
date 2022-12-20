using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.crimson_nylium)]
    public class crimson_nylium : IBlockData
    {
        public short DefaultStateID => 15241;
        public state DefaultState => States[0];
        public float Hardness => 0.4f;
        public float ExplosionResistance => 0.4f;
        public bool IsTransparent => false;
        public byte SoundGroup => 27;
        public short DroppedItem => 19;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15241,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
