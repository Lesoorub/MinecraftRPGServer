using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.crimson_trapdoor)]
    public class crimson_trapdoor : IBlockData
    {
        public short DefaultStateID => 15396;
        public state DefaultState => States[15];
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 647;
        public MinecraftMaterial Material => MinecraftMaterial.nether_wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "half", new List<string>() { "top", "bottom" } },
            { "open", new List<string>() { "True", "False" } },
            { "powered", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15381,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15382,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15383,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15384,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15385,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15386,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15387,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15388,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15389,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15390,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15391,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15392,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15393,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15394,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15395,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15396,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15397,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15398,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15399,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15400,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15401,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15402,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15403,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15404,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15405,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15406,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15407,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15408,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15409,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15410,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15411,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15412,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15413,
                Properties = new byte[] { 2,0,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15414,
                Properties = new byte[] { 2,0,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15415,
                Properties = new byte[] { 2,0,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15416,
                Properties = new byte[] { 2,0,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15417,
                Properties = new byte[] { 2,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15418,
                Properties = new byte[] { 2,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15419,
                Properties = new byte[] { 2,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15420,
                Properties = new byte[] { 2,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15421,
                Properties = new byte[] { 2,1,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15422,
                Properties = new byte[] { 2,1,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15423,
                Properties = new byte[] { 2,1,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15424,
                Properties = new byte[] { 2,1,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15425,
                Properties = new byte[] { 2,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15426,
                Properties = new byte[] { 2,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15427,
                Properties = new byte[] { 2,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15428,
                Properties = new byte[] { 2,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15429,
                Properties = new byte[] { 3,0,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15430,
                Properties = new byte[] { 3,0,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15431,
                Properties = new byte[] { 3,0,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15432,
                Properties = new byte[] { 3,0,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15433,
                Properties = new byte[] { 3,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15434,
                Properties = new byte[] { 3,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15435,
                Properties = new byte[] { 3,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15436,
                Properties = new byte[] { 3,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15437,
                Properties = new byte[] { 3,1,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15438,
                Properties = new byte[] { 3,1,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15439,
                Properties = new byte[] { 3,1,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15440,
                Properties = new byte[] { 3,1,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15441,
                Properties = new byte[] { 3,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15442,
                Properties = new byte[] { 3,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15443,
                Properties = new byte[] { 3,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15444,
                Properties = new byte[] { 3,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
