using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.stone_stairs)]
    public class stone_stairs : IBlockData
    {
        public short DefaultStateID => 10410;
        public state DefaultState => States[11];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 555;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "half", new List<string>() { "top", "bottom" } },
            { "shape", new List<string>() { "straight", "inner_left", "inner_right", "outer_left", "outer_right" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 10399,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 78,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10400,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 78,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10401,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10402,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10403,
                Properties = new byte[] { 0,0,2,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10404,
                Properties = new byte[] { 0,0,2,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10405,
                Properties = new byte[] { 0,0,3,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10406,
                Properties = new byte[] { 0,0,3,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10407,
                Properties = new byte[] { 0,0,4,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10408,
                Properties = new byte[] { 0,0,4,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10409,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 91,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10410,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 91,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10411,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10412,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10413,
                Properties = new byte[] { 0,1,2,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10414,
                Properties = new byte[] { 0,1,2,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10415,
                Properties = new byte[] { 0,1,3,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10416,
                Properties = new byte[] { 0,1,3,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10417,
                Properties = new byte[] { 0,1,4,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10418,
                Properties = new byte[] { 0,1,4,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10419,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 98,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10420,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 98,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10421,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10422,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10423,
                Properties = new byte[] { 1,0,2,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10424,
                Properties = new byte[] { 1,0,2,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10425,
                Properties = new byte[] { 1,0,3,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10426,
                Properties = new byte[] { 1,0,3,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10427,
                Properties = new byte[] { 1,0,4,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10428,
                Properties = new byte[] { 1,0,4,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10429,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 108,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10430,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 108,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10431,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10432,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10433,
                Properties = new byte[] { 1,1,2,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10434,
                Properties = new byte[] { 1,1,2,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10435,
                Properties = new byte[] { 1,1,3,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10436,
                Properties = new byte[] { 1,1,3,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10437,
                Properties = new byte[] { 1,1,4,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10438,
                Properties = new byte[] { 1,1,4,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10439,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 83,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10440,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 83,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10441,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10442,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10443,
                Properties = new byte[] { 2,0,2,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10444,
                Properties = new byte[] { 2,0,2,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10445,
                Properties = new byte[] { 2,0,3,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10446,
                Properties = new byte[] { 2,0,3,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10447,
                Properties = new byte[] { 2,0,4,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10448,
                Properties = new byte[] { 2,0,4,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10449,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 93,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10450,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 93,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10451,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10452,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10453,
                Properties = new byte[] { 2,1,2,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10454,
                Properties = new byte[] { 2,1,2,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10455,
                Properties = new byte[] { 2,1,3,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10456,
                Properties = new byte[] { 2,1,3,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10457,
                Properties = new byte[] { 2,1,4,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10458,
                Properties = new byte[] { 2,1,4,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10459,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 86,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10460,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 86,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10461,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10462,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10463,
                Properties = new byte[] { 3,0,2,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10464,
                Properties = new byte[] { 3,0,2,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10465,
                Properties = new byte[] { 3,0,3,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10466,
                Properties = new byte[] { 3,0,3,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10467,
                Properties = new byte[] { 3,0,4,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10468,
                Properties = new byte[] { 3,0,4,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10469,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 95,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10470,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 95,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10471,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10472,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10473,
                Properties = new byte[] { 3,1,2,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10474,
                Properties = new byte[] { 3,1,2,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10475,
                Properties = new byte[] { 3,1,3,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10476,
                Properties = new byte[] { 3,1,3,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10477,
                Properties = new byte[] { 3,1,4,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 10478,
                Properties = new byte[] { 3,1,4,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
