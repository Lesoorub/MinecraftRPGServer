using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.brewing_stand)]
    public class brewing_stand : IBlockData
    {
        public short DefaultStateID => 5341;
        public state DefaultState => States[7];
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 869;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "has_bottle_0", new List<string>() { "True", "False" } },
            { "has_bottle_1", new List<string>() { "True", "False" } },
            { "has_bottle_2", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5334,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5335,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5336,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5337,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5338,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5339,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5340,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5341,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 369,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
