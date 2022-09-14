using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.light_blue_candle)]
    public class light_blue_candle : IBlockData
    {
        public short DefaultStateID => 17425;
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => true;
        public byte SoundGroup => 48;
        public short DroppedItem => 1083;
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
                Id = 17422,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17423,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17424,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 322,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17425,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 322,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17426,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17427,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17428,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 737,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17429,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 737,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17430,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17431,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17432,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 738,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17433,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 738,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17434,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17435,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17436,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 739,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17437,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 739,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
