using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.nether_brick_stairs)]
    public class nether_brick_stairs : IBlockData
    {
        public short DefaultStateID => 5260;
        public float Hardness => 2f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 38;
        public short DroppedItem => 309;
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
                Id = 5249,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 78,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5250,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 78,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5251,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5252,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5253,
                Properties = new byte[] { 0,0,2,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5254,
                Properties = new byte[] { 0,0,2,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5255,
                Properties = new byte[] { 0,0,3,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5256,
                Properties = new byte[] { 0,0,3,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5257,
                Properties = new byte[] { 0,0,4,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5258,
                Properties = new byte[] { 0,0,4,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5259,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 91,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5260,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 91,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5261,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5262,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5263,
                Properties = new byte[] { 0,1,2,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5264,
                Properties = new byte[] { 0,1,2,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5265,
                Properties = new byte[] { 0,1,3,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5266,
                Properties = new byte[] { 0,1,3,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5267,
                Properties = new byte[] { 0,1,4,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5268,
                Properties = new byte[] { 0,1,4,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5269,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 98,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5270,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 98,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5271,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5272,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5273,
                Properties = new byte[] { 1,0,2,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5274,
                Properties = new byte[] { 1,0,2,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5275,
                Properties = new byte[] { 1,0,3,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5276,
                Properties = new byte[] { 1,0,3,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5277,
                Properties = new byte[] { 1,0,4,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5278,
                Properties = new byte[] { 1,0,4,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5279,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 108,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5280,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 108,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5281,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5282,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5283,
                Properties = new byte[] { 1,1,2,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5284,
                Properties = new byte[] { 1,1,2,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5285,
                Properties = new byte[] { 1,1,3,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5286,
                Properties = new byte[] { 1,1,3,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5287,
                Properties = new byte[] { 1,1,4,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5288,
                Properties = new byte[] { 1,1,4,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5289,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 83,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5290,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 83,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5291,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5292,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5293,
                Properties = new byte[] { 2,0,2,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5294,
                Properties = new byte[] { 2,0,2,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5295,
                Properties = new byte[] { 2,0,3,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5296,
                Properties = new byte[] { 2,0,3,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5297,
                Properties = new byte[] { 2,0,4,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5298,
                Properties = new byte[] { 2,0,4,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5299,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 93,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5300,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 93,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5301,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5302,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5303,
                Properties = new byte[] { 2,1,2,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5304,
                Properties = new byte[] { 2,1,2,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5305,
                Properties = new byte[] { 2,1,3,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5306,
                Properties = new byte[] { 2,1,3,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5307,
                Properties = new byte[] { 2,1,4,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5308,
                Properties = new byte[] { 2,1,4,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5309,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 86,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5310,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 86,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5311,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5312,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5313,
                Properties = new byte[] { 3,0,2,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5314,
                Properties = new byte[] { 3,0,2,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5315,
                Properties = new byte[] { 3,0,3,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5316,
                Properties = new byte[] { 3,0,3,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5317,
                Properties = new byte[] { 3,0,4,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5318,
                Properties = new byte[] { 3,0,4,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5319,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 95,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5320,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 95,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5321,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5322,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5323,
                Properties = new byte[] { 3,1,2,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5324,
                Properties = new byte[] { 3,1,2,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5325,
                Properties = new byte[] { 3,1,3,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5326,
                Properties = new byte[] { 3,1,3,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5327,
                Properties = new byte[] { 3,1,4,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5328,
                Properties = new byte[] { 3,1,4,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
