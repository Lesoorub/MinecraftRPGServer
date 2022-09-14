using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.magenta_candle)]
    public class magenta_candle : IBlockData
    {
        public short DefaultStateID => 17409;
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => true;
        public byte SoundGroup => 48;
        public short DroppedItem => 1082;
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
                Id = 17406,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17407,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17408,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17409,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17410,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17411,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17412,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17413,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17414,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17415,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17416,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17417,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17418,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17419,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17420,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17421,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
