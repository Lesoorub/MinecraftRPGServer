using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.infested_stone_bricks)]
    public class infested_stone_bricks : IBlockData
    {
        public short DefaultStateID => 4570;
        public state DefaultState => States[0];
        public float Hardness => 0.75f;
        public float ExplosionResistance => 0.75f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 278;
        public MinecraftMaterial Material => MinecraftMaterial.organic_product;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4570,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
