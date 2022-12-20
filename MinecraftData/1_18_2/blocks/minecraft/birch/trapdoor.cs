using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.birch_trapdoor)]
    public class birch_trapdoor : IBlockData
    {
        public short DefaultStateID => 4323;
        public state DefaultState => States[15];
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 643;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
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
                Id = 4308,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4309,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4310,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4311,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4312,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4313,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4314,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4315,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4316,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4317,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4318,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4319,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4320,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4321,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4322,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4323,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4324,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4325,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4326,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4327,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4328,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4329,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4330,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4331,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4332,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4333,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4334,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4335,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4336,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4337,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4338,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4339,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4340,
                Properties = new byte[] { 2,0,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4341,
                Properties = new byte[] { 2,0,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4342,
                Properties = new byte[] { 2,0,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4343,
                Properties = new byte[] { 2,0,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4344,
                Properties = new byte[] { 2,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4345,
                Properties = new byte[] { 2,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4346,
                Properties = new byte[] { 2,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4347,
                Properties = new byte[] { 2,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4348,
                Properties = new byte[] { 2,1,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4349,
                Properties = new byte[] { 2,1,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4350,
                Properties = new byte[] { 2,1,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4351,
                Properties = new byte[] { 2,1,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4352,
                Properties = new byte[] { 2,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4353,
                Properties = new byte[] { 2,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4354,
                Properties = new byte[] { 2,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4355,
                Properties = new byte[] { 2,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4356,
                Properties = new byte[] { 3,0,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4357,
                Properties = new byte[] { 3,0,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4358,
                Properties = new byte[] { 3,0,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4359,
                Properties = new byte[] { 3,0,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4360,
                Properties = new byte[] { 3,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4361,
                Properties = new byte[] { 3,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4362,
                Properties = new byte[] { 3,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4363,
                Properties = new byte[] { 3,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4364,
                Properties = new byte[] { 3,1,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4365,
                Properties = new byte[] { 3,1,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4366,
                Properties = new byte[] { 3,1,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4367,
                Properties = new byte[] { 3,1,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4368,
                Properties = new byte[] { 3,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4369,
                Properties = new byte[] { 3,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4370,
                Properties = new byte[] { 3,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4371,
                Properties = new byte[] { 3,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
