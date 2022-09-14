using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.lightning_rod)]
    public class lightning_rod : IBlockData
    {
        public short DefaultStateID => 18539;
        public float Hardness => 3f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => true;
        public byte SoundGroup => 58;
        public short DroppedItem => 601;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } },
            { "powered", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18520,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 20,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18521,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 20,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18522,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 20,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18523,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 20,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18524,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 24,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18525,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 24,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18526,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 24,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18527,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 24,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18528,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 20,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18529,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 20,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18530,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 20,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18531,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 20,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18532,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 24,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18533,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 24,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18534,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 24,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18535,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 24,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18536,
                Properties = new byte[] { 4,0,0 },
                CollisionShape = 33,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18537,
                Properties = new byte[] { 4,0,1 },
                CollisionShape = 33,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18538,
                Properties = new byte[] { 4,1,0 },
                CollisionShape = 33,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18539,
                Properties = new byte[] { 4,1,1 },
                CollisionShape = 33,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18540,
                Properties = new byte[] { 5,0,0 },
                CollisionShape = 33,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18541,
                Properties = new byte[] { 5,0,1 },
                CollisionShape = 33,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18542,
                Properties = new byte[] { 5,1,0 },
                CollisionShape = 33,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18543,
                Properties = new byte[] { 5,1,1 },
                CollisionShape = 33,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
