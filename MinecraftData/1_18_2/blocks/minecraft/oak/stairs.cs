using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.oak_stairs)]
    public class oak_stairs : IBlockData
    {
        public short DefaultStateID => 2021;
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 244;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
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
                Id = 2010,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 78,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2011,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 78,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2012,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2013,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2014,
                Properties = new byte[] { 0,0,2,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2015,
                Properties = new byte[] { 0,0,2,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2016,
                Properties = new byte[] { 0,0,3,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2017,
                Properties = new byte[] { 0,0,3,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2018,
                Properties = new byte[] { 0,0,4,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2019,
                Properties = new byte[] { 0,0,4,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2020,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 91,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2021,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 91,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2022,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2023,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2024,
                Properties = new byte[] { 0,1,2,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2025,
                Properties = new byte[] { 0,1,2,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2026,
                Properties = new byte[] { 0,1,3,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2027,
                Properties = new byte[] { 0,1,3,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2028,
                Properties = new byte[] { 0,1,4,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2029,
                Properties = new byte[] { 0,1,4,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2030,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 98,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2031,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 98,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2032,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2033,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2034,
                Properties = new byte[] { 1,0,2,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2035,
                Properties = new byte[] { 1,0,2,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2036,
                Properties = new byte[] { 1,0,3,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2037,
                Properties = new byte[] { 1,0,3,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2038,
                Properties = new byte[] { 1,0,4,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2039,
                Properties = new byte[] { 1,0,4,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2040,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 108,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2041,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 108,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2042,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2043,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2044,
                Properties = new byte[] { 1,1,2,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2045,
                Properties = new byte[] { 1,1,2,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2046,
                Properties = new byte[] { 1,1,3,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2047,
                Properties = new byte[] { 1,1,3,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2048,
                Properties = new byte[] { 1,1,4,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2049,
                Properties = new byte[] { 1,1,4,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2050,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 83,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2051,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 83,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2052,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2053,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2054,
                Properties = new byte[] { 2,0,2,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2055,
                Properties = new byte[] { 2,0,2,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2056,
                Properties = new byte[] { 2,0,3,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2057,
                Properties = new byte[] { 2,0,3,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2058,
                Properties = new byte[] { 2,0,4,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2059,
                Properties = new byte[] { 2,0,4,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2060,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 93,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2061,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 93,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2062,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2063,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2064,
                Properties = new byte[] { 2,1,2,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2065,
                Properties = new byte[] { 2,1,2,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2066,
                Properties = new byte[] { 2,1,3,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2067,
                Properties = new byte[] { 2,1,3,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2068,
                Properties = new byte[] { 2,1,4,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2069,
                Properties = new byte[] { 2,1,4,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2070,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 86,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2071,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 86,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2072,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2073,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2074,
                Properties = new byte[] { 3,0,2,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2075,
                Properties = new byte[] { 3,0,2,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2076,
                Properties = new byte[] { 3,0,3,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2077,
                Properties = new byte[] { 3,0,3,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2078,
                Properties = new byte[] { 3,0,4,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2079,
                Properties = new byte[] { 3,0,4,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2080,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 95,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2081,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 95,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2082,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2083,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2084,
                Properties = new byte[] { 3,1,2,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2085,
                Properties = new byte[] { 3,1,2,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2086,
                Properties = new byte[] { 3,1,3,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2087,
                Properties = new byte[] { 3,1,3,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2088,
                Properties = new byte[] { 3,1,4,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 2089,
                Properties = new byte[] { 3,1,4,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
