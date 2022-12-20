using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.stone_brick_stairs)]
    public class stone_brick_stairs : IBlockData
    {
        public short DefaultStateID => 5144;
        public state DefaultState => States[11];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 302;
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
                Id = 5133,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 78,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5134,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 78,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5135,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5136,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5137,
                Properties = new byte[] { 0,0,2,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5138,
                Properties = new byte[] { 0,0,2,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5139,
                Properties = new byte[] { 0,0,3,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5140,
                Properties = new byte[] { 0,0,3,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5141,
                Properties = new byte[] { 0,0,4,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5142,
                Properties = new byte[] { 0,0,4,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5143,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 91,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5144,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 91,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5145,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5146,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5147,
                Properties = new byte[] { 0,1,2,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5148,
                Properties = new byte[] { 0,1,2,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5149,
                Properties = new byte[] { 0,1,3,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5150,
                Properties = new byte[] { 0,1,3,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5151,
                Properties = new byte[] { 0,1,4,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5152,
                Properties = new byte[] { 0,1,4,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5153,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 98,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5154,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 98,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5155,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5156,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5157,
                Properties = new byte[] { 1,0,2,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5158,
                Properties = new byte[] { 1,0,2,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5159,
                Properties = new byte[] { 1,0,3,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5160,
                Properties = new byte[] { 1,0,3,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5161,
                Properties = new byte[] { 1,0,4,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5162,
                Properties = new byte[] { 1,0,4,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5163,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 108,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5164,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 108,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5165,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5166,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5167,
                Properties = new byte[] { 1,1,2,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5168,
                Properties = new byte[] { 1,1,2,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5169,
                Properties = new byte[] { 1,1,3,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5170,
                Properties = new byte[] { 1,1,3,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5171,
                Properties = new byte[] { 1,1,4,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5172,
                Properties = new byte[] { 1,1,4,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5173,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 83,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5174,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 83,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5175,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 102,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5176,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 102,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5177,
                Properties = new byte[] { 2,0,2,0 },
                CollisionShape = 81,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5178,
                Properties = new byte[] { 2,0,2,1 },
                CollisionShape = 81,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5179,
                Properties = new byte[] { 2,0,3,0 },
                CollisionShape = 106,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5180,
                Properties = new byte[] { 2,0,3,1 },
                CollisionShape = 106,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5181,
                Properties = new byte[] { 2,0,4,0 },
                CollisionShape = 87,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5182,
                Properties = new byte[] { 2,0,4,1 },
                CollisionShape = 87,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5183,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 93,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5184,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 93,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5185,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 110,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5186,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 110,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5187,
                Properties = new byte[] { 2,1,2,0 },
                CollisionShape = 92,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5188,
                Properties = new byte[] { 2,1,2,1 },
                CollisionShape = 92,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5189,
                Properties = new byte[] { 2,1,3,0 },
                CollisionShape = 112,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5190,
                Properties = new byte[] { 2,1,3,1 },
                CollisionShape = 112,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5191,
                Properties = new byte[] { 2,1,4,0 },
                CollisionShape = 96,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5192,
                Properties = new byte[] { 2,1,4,1 },
                CollisionShape = 96,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5193,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 86,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5194,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 86,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5195,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 84,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5196,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 84,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5197,
                Properties = new byte[] { 3,0,2,0 },
                CollisionShape = 100,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5198,
                Properties = new byte[] { 3,0,2,1 },
                CollisionShape = 100,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5199,
                Properties = new byte[] { 3,0,3,0 },
                CollisionShape = 89,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5200,
                Properties = new byte[] { 3,0,3,1 },
                CollisionShape = 89,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5201,
                Properties = new byte[] { 3,0,4,0 },
                CollisionShape = 104,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5202,
                Properties = new byte[] { 3,0,4,1 },
                CollisionShape = 104,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5203,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 95,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5204,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 95,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5205,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 94,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5206,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 94,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5207,
                Properties = new byte[] { 3,1,2,0 },
                CollisionShape = 109,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5208,
                Properties = new byte[] { 3,1,2,1 },
                CollisionShape = 109,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5209,
                Properties = new byte[] { 3,1,3,0 },
                CollisionShape = 97,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5210,
                Properties = new byte[] { 3,1,3,1 },
                CollisionShape = 97,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5211,
                Properties = new byte[] { 3,1,4,0 },
                CollisionShape = 111,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5212,
                Properties = new byte[] { 3,1,4,1 },
                CollisionShape = 111,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
