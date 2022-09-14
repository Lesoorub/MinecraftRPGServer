using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.infested_stone)]
    public class infested_stone : IBlockData
    {
        public short DefaultStateID => 4568;
        public float Hardness => 0.75f;
        public float ExplosionResistance => 0.75f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 276;
        public MinecraftMaterial Material => MinecraftMaterial.organic_product;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4568,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
