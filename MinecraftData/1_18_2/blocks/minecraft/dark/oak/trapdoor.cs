using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dark_oak_trapdoor)]
    public class dark_oak_trapdoor : IBlockData
    {
        public short DefaultStateID => 4515;
        public state DefaultState => States[15];
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 646;
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
                Id = 4500,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4501,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4502,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4503,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4504,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4505,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4506,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4507,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4508,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4509,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4510,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4511,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4512,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4513,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4514,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4515,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4516,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4517,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4518,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4519,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4520,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4521,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4522,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4523,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4524,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4525,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4526,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4527,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4528,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4529,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4530,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4531,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4532,
                Properties = new byte[] { 2,0,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4533,
                Properties = new byte[] { 2,0,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4534,
                Properties = new byte[] { 2,0,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4535,
                Properties = new byte[] { 2,0,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4536,
                Properties = new byte[] { 2,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4537,
                Properties = new byte[] { 2,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4538,
                Properties = new byte[] { 2,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4539,
                Properties = new byte[] { 2,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4540,
                Properties = new byte[] { 2,1,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4541,
                Properties = new byte[] { 2,1,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4542,
                Properties = new byte[] { 2,1,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4543,
                Properties = new byte[] { 2,1,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4544,
                Properties = new byte[] { 2,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4545,
                Properties = new byte[] { 2,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4546,
                Properties = new byte[] { 2,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4547,
                Properties = new byte[] { 2,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4548,
                Properties = new byte[] { 3,0,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4549,
                Properties = new byte[] { 3,0,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4550,
                Properties = new byte[] { 3,0,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4551,
                Properties = new byte[] { 3,0,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4552,
                Properties = new byte[] { 3,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4553,
                Properties = new byte[] { 3,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4554,
                Properties = new byte[] { 3,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4555,
                Properties = new byte[] { 3,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4556,
                Properties = new byte[] { 3,1,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4557,
                Properties = new byte[] { 3,1,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4558,
                Properties = new byte[] { 3,1,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4559,
                Properties = new byte[] { 3,1,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4560,
                Properties = new byte[] { 3,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4561,
                Properties = new byte[] { 3,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4562,
                Properties = new byte[] { 3,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4563,
                Properties = new byte[] { 3,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
