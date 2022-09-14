using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cyan_candle)]
    public class cyan_candle : IBlockData
    {
        public short DefaultStateID => 17521;
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => true;
        public byte SoundGroup => 48;
        public short DroppedItem => 1089;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "candles", new List<string>() { "1", "2", "3", "4" } },
            { "lit", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17518,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17519,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17520,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17521,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17522,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17523,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17524,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17525,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17526,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17527,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17528,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17529,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17530,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17531,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17532,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17533,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
