using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.chest)]
    public class chest : IBlockData
    {
        public short DefaultStateID => 2091;
        public float Hardness => 2.5f;
        public float ExplosionResistance => 2.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 245;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "type", new List<string>() { "single", "left", "right" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 2090,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2091,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2092,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 117,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2093,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 117,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2094,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = 120,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2095,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = 120,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2096,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2097,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2098,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 120,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2099,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 120,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2100,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = 117,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2101,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = 117,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2102,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2103,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2104,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 122,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2105,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 122,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2106,
                Properties = new byte[] { 2,2,0 },
                CollisionShape = 125,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2107,
                Properties = new byte[] { 2,2,1 },
                CollisionShape = 125,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2108,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2109,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2110,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 125,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2111,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 125,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2112,
                Properties = new byte[] { 3,2,0 },
                CollisionShape = 122,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 2113,
                Properties = new byte[] { 3,2,1 },
                CollisionShape = 122,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
