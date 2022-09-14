using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.orange_candle)]
    public class orange_candle : IBlockData
    {
        public short DefaultStateID => 17393;
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => true;
        public byte SoundGroup => 48;
        public short DroppedItem => 1081;
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
                Id = 17390,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17391,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17392,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17393,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17394,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17395,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17396,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17397,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17398,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17399,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17400,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17401,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17402,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17403,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17404,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17405,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
