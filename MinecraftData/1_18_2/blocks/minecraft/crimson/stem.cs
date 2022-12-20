using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.crimson_stem)]
    public class crimson_stem : IBlockData
    {
        public short DefaultStateID => 15230;
        public state DefaultState => States[1];
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => false;
        public byte SoundGroup => 26;
        public short DroppedItem => 107;
        public MinecraftMaterial Material => MinecraftMaterial.nether_wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "axis", new List<string>() { "x", "y", "z" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15229,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15230,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15231,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
