using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cactus)]
    public class cactus : IBlockData
    {
        public short DefaultStateID => 4000;
        public state DefaultState => States[0];
        public float Hardness => 0.4f;
        public float ExplosionResistance => 0.4f;
        public bool IsTransparent => false;
        public byte SoundGroup => 7;
        public short DroppedItem => 254;
        public MinecraftMaterial Material => MinecraftMaterial.cactus;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "age", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4000,
                Properties = new byte[] { 0 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4001,
                Properties = new byte[] { 1 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4002,
                Properties = new byte[] { 2 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4003,
                Properties = new byte[] { 3 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4004,
                Properties = new byte[] { 4 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4005,
                Properties = new byte[] { 5 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4006,
                Properties = new byte[] { 6 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4007,
                Properties = new byte[] { 7 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4008,
                Properties = new byte[] { 8 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4009,
                Properties = new byte[] { 9 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4010,
                Properties = new byte[] { 10 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4011,
                Properties = new byte[] { 11 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4012,
                Properties = new byte[] { 12 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4013,
                Properties = new byte[] { 13 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4014,
                Properties = new byte[] { 14 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4015,
                Properties = new byte[] { 15 },
                CollisionShape = 247,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
