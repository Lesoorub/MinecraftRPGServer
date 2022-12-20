using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.polished_blackstone_stairs)]
    public class polished_blackstone_stairs : IBlockData
    {
        public short DefaultStateID => 16930;
        public state DefaultState => States[11];
        public float Hardness => 2f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 1072;
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
                Id = 16919,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 78,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16920,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 78,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16921,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16922,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16923,
                Properties = new byte[] { 0,0,2,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16924,
                Properties = new byte[] { 0,0,2,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16925,
                Properties = new byte[] { 0,0,3,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16926,
                Properties = new byte[] { 0,0,3,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16927,
                Properties = new byte[] { 0,0,4,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16928,
                Properties = new byte[] { 0,0,4,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16929,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 91,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16930,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 91,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16931,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16932,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16933,
                Properties = new byte[] { 0,1,2,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16934,
                Properties = new byte[] { 0,1,2,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16935,
                Properties = new byte[] { 0,1,3,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16936,
                Properties = new byte[] { 0,1,3,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16937,
                Properties = new byte[] { 0,1,4,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16938,
                Properties = new byte[] { 0,1,4,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16939,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 98,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16940,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 98,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16941,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16942,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16943,
                Properties = new byte[] { 1,0,2,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16944,
                Properties = new byte[] { 1,0,2,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16945,
                Properties = new byte[] { 1,0,3,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16946,
                Properties = new byte[] { 1,0,3,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16947,
                Properties = new byte[] { 1,0,4,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16948,
                Properties = new byte[] { 1,0,4,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16949,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 108,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16950,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 108,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16951,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16952,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16953,
                Properties = new byte[] { 1,1,2,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16954,
                Properties = new byte[] { 1,1,2,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16955,
                Properties = new byte[] { 1,1,3,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16956,
                Properties = new byte[] { 1,1,3,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16957,
                Properties = new byte[] { 1,1,4,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16958,
                Properties = new byte[] { 1,1,4,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16959,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 83,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16960,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 83,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16961,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16962,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16963,
                Properties = new byte[] { 2,0,2,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16964,
                Properties = new byte[] { 2,0,2,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16965,
                Properties = new byte[] { 2,0,3,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16966,
                Properties = new byte[] { 2,0,3,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16967,
                Properties = new byte[] { 2,0,4,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16968,
                Properties = new byte[] { 2,0,4,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16969,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 93,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16970,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 93,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16971,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16972,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16973,
                Properties = new byte[] { 2,1,2,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16974,
                Properties = new byte[] { 2,1,2,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16975,
                Properties = new byte[] { 2,1,3,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16976,
                Properties = new byte[] { 2,1,3,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16977,
                Properties = new byte[] { 2,1,4,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16978,
                Properties = new byte[] { 2,1,4,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16979,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 86,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16980,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 86,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16981,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16982,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16983,
                Properties = new byte[] { 3,0,2,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16984,
                Properties = new byte[] { 3,0,2,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16985,
                Properties = new byte[] { 3,0,3,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16986,
                Properties = new byte[] { 3,0,3,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16987,
                Properties = new byte[] { 3,0,4,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16988,
                Properties = new byte[] { 3,0,4,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16989,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 95,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16990,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 95,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16991,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16992,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16993,
                Properties = new byte[] { 3,1,2,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16994,
                Properties = new byte[] { 3,1,2,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16995,
                Properties = new byte[] { 3,1,3,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16996,
                Properties = new byte[] { 3,1,3,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16997,
                Properties = new byte[] { 3,1,4,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 16998,
                Properties = new byte[] { 3,1,4,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
