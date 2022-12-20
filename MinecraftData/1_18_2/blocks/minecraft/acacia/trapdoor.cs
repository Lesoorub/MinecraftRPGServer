using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.acacia_trapdoor)]
    public class acacia_trapdoor : IBlockData
    {
        public short DefaultStateID => 4451;
        public state DefaultState => States[15];
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 645;
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
                Id = 4436,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4437,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4438,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4439,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4440,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4441,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4442,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4443,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4444,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4445,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4446,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4447,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4448,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4449,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4450,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4451,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4452,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4453,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4454,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4455,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4456,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4457,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4458,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4459,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4460,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4461,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4462,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4463,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4464,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4465,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4466,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4467,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4468,
                Properties = new byte[] { 2,0,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4469,
                Properties = new byte[] { 2,0,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4470,
                Properties = new byte[] { 2,0,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4471,
                Properties = new byte[] { 2,0,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4472,
                Properties = new byte[] { 2,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4473,
                Properties = new byte[] { 2,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4474,
                Properties = new byte[] { 2,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4475,
                Properties = new byte[] { 2,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4476,
                Properties = new byte[] { 2,1,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4477,
                Properties = new byte[] { 2,1,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4478,
                Properties = new byte[] { 2,1,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4479,
                Properties = new byte[] { 2,1,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4480,
                Properties = new byte[] { 2,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4481,
                Properties = new byte[] { 2,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4482,
                Properties = new byte[] { 2,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4483,
                Properties = new byte[] { 2,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4484,
                Properties = new byte[] { 3,0,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4485,
                Properties = new byte[] { 3,0,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4486,
                Properties = new byte[] { 3,0,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4487,
                Properties = new byte[] { 3,0,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4488,
                Properties = new byte[] { 3,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4489,
                Properties = new byte[] { 3,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4490,
                Properties = new byte[] { 3,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4491,
                Properties = new byte[] { 3,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4492,
                Properties = new byte[] { 3,1,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4493,
                Properties = new byte[] { 3,1,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4494,
                Properties = new byte[] { 3,1,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4495,
                Properties = new byte[] { 3,1,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4496,
                Properties = new byte[] { 3,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4497,
                Properties = new byte[] { 3,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4498,
                Properties = new byte[] { 3,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4499,
                Properties = new byte[] { 3,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
