using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.infested_deepslate)]
    public class infested_deepslate : IBlockData
    {
        public short DefaultStateID => 20334;
        public float Hardness => 1.5f;
        public float ExplosionResistance => 0.75f;
        public bool IsTransparent => false;
        public byte SoundGroup => 72;
        public short DroppedItem => 282;
        public MinecraftMaterial Material => MinecraftMaterial.organic_product;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "axis", new List<string>() { "x", "y", "z" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 20333,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 20334,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 20335,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
