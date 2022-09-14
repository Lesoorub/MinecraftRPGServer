using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.oak_trapdoor)]
    public class oak_trapdoor : IBlockData
    {
        public short DefaultStateID => 4195;
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 641;
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
                Id = 4180,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4181,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4182,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4183,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4184,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4185,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4186,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4187,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4188,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4189,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4190,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4191,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4192,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4193,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4194,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4195,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4196,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4197,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4198,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4199,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4200,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4201,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4202,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4203,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4204,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4205,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4206,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4207,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4208,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4209,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4210,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4211,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4212,
                Properties = new byte[] { 2,0,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4213,
                Properties = new byte[] { 2,0,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4214,
                Properties = new byte[] { 2,0,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4215,
                Properties = new byte[] { 2,0,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4216,
                Properties = new byte[] { 2,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4217,
                Properties = new byte[] { 2,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4218,
                Properties = new byte[] { 2,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4219,
                Properties = new byte[] { 2,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4220,
                Properties = new byte[] { 2,1,0,0,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4221,
                Properties = new byte[] { 2,1,0,0,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4222,
                Properties = new byte[] { 2,1,0,1,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4223,
                Properties = new byte[] { 2,1,0,1,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4224,
                Properties = new byte[] { 2,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4225,
                Properties = new byte[] { 2,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4226,
                Properties = new byte[] { 2,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4227,
                Properties = new byte[] { 2,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4228,
                Properties = new byte[] { 3,0,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4229,
                Properties = new byte[] { 3,0,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4230,
                Properties = new byte[] { 3,0,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4231,
                Properties = new byte[] { 3,0,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4232,
                Properties = new byte[] { 3,0,1,0,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4233,
                Properties = new byte[] { 3,0,1,0,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4234,
                Properties = new byte[] { 3,0,1,1,0 },
                CollisionShape = 295,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4235,
                Properties = new byte[] { 3,0,1,1,1 },
                CollisionShape = 295,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4236,
                Properties = new byte[] { 3,1,0,0,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4237,
                Properties = new byte[] { 3,1,0,0,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4238,
                Properties = new byte[] { 3,1,0,1,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4239,
                Properties = new byte[] { 3,1,0,1,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4240,
                Properties = new byte[] { 3,1,1,0,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4241,
                Properties = new byte[] { 3,1,1,0,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4242,
                Properties = new byte[] { 3,1,1,1,0 },
                CollisionShape = 296,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4243,
                Properties = new byte[] { 3,1,1,1,1 },
                CollisionShape = 296,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
