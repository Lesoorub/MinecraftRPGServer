using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.stripped_jungle_log)]
    public class stripped_jungle_log : IBlockData
    {
        public short DefaultStateID => 101;
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 112;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "axis", new List<string>() { "x", "y", "z" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 100,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 101,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 102,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
