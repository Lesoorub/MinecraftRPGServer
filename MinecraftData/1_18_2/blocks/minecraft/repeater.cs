using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.repeater)]
    public class repeater : IBlockData
    {
        public short DefaultStateID => 4103;
        public state DefaultState => States[3];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 588;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "delay", new List<string>() { "1", "2", "3", "4" } },
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "locked", new List<string>() { "True", "False" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4100,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4101,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4102,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4103,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4104,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4105,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4106,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4107,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4108,
                Properties = new byte[] { 0,2,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4109,
                Properties = new byte[] { 0,2,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4110,
                Properties = new byte[] { 0,2,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4111,
                Properties = new byte[] { 0,2,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4112,
                Properties = new byte[] { 0,3,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4113,
                Properties = new byte[] { 0,3,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4114,
                Properties = new byte[] { 0,3,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4115,
                Properties = new byte[] { 0,3,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4116,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4117,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4118,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4119,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4120,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4121,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4122,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4123,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4124,
                Properties = new byte[] { 1,2,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4125,
                Properties = new byte[] { 1,2,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4126,
                Properties = new byte[] { 1,2,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4127,
                Properties = new byte[] { 1,2,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4128,
                Properties = new byte[] { 1,3,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4129,
                Properties = new byte[] { 1,3,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4130,
                Properties = new byte[] { 1,3,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4131,
                Properties = new byte[] { 1,3,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4132,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4133,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4134,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4135,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4136,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4137,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4138,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4139,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4140,
                Properties = new byte[] { 2,2,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4141,
                Properties = new byte[] { 2,2,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4142,
                Properties = new byte[] { 2,2,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4143,
                Properties = new byte[] { 2,2,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4144,
                Properties = new byte[] { 2,3,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4145,
                Properties = new byte[] { 2,3,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4146,
                Properties = new byte[] { 2,3,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4147,
                Properties = new byte[] { 2,3,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4148,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4149,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4150,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4151,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4152,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4153,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4154,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4155,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4156,
                Properties = new byte[] { 3,2,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4157,
                Properties = new byte[] { 3,2,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4158,
                Properties = new byte[] { 3,2,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4159,
                Properties = new byte[] { 3,2,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4160,
                Properties = new byte[] { 3,3,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4161,
                Properties = new byte[] { 3,3,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4162,
                Properties = new byte[] { 3,3,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4163,
                Properties = new byte[] { 3,3,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
