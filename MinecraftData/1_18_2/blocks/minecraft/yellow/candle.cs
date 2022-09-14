using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.yellow_candle)]
    public class yellow_candle : IBlockData
    {
        public short DefaultStateID => 17441;
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => true;
        public byte SoundGroup => 48;
        public short DroppedItem => 1084;
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
                Id = 17438,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17439,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17440,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17441,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17442,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17443,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17444,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17445,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17446,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17447,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17448,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17449,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17450,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17451,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17452,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17453,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
