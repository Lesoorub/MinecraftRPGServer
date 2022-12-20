using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.piston_head)]
    public class piston_head : IBlockData
    {
        public short DefaultStateID => 1418;
        public state DefaultState => States[2];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.piston;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } },
            { "short", new List<string>() { "True", "False" } },
            { "type", new List<string>() { "normal", "sticky" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1416,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 18,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1417,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 18,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1418,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 21,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1419,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 21,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1420,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 22,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1421,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 22,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1422,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 25,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1423,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 25,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1424,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 26,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1425,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 26,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1426,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 28,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1427,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 28,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1428,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 29,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1429,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 29,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1430,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 31,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1431,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 31,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1432,
                Properties = new byte[] { 4,0,0 },
                CollisionShape = 32,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1433,
                Properties = new byte[] { 4,0,1 },
                CollisionShape = 32,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1434,
                Properties = new byte[] { 4,1,0 },
                CollisionShape = 35,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1435,
                Properties = new byte[] { 4,1,1 },
                CollisionShape = 35,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1436,
                Properties = new byte[] { 5,0,0 },
                CollisionShape = 36,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1437,
                Properties = new byte[] { 5,0,1 },
                CollisionShape = 36,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1438,
                Properties = new byte[] { 5,1,0 },
                CollisionShape = 38,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1439,
                Properties = new byte[] { 5,1,1 },
                CollisionShape = 38,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
