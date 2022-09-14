using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.water)]
    public class water : IBlockData
    {
        public short DefaultStateID => 34;
        public float Hardness => 100f;
        public float ExplosionResistance => 100f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.water;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "level", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 34,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 35,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 36,
                Properties = new byte[] { 2 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 37,
                Properties = new byte[] { 3 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 38,
                Properties = new byte[] { 4 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 39,
                Properties = new byte[] { 5 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 40,
                Properties = new byte[] { 6 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 41,
                Properties = new byte[] { 7 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 42,
                Properties = new byte[] { 8 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 43,
                Properties = new byte[] { 9 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 44,
                Properties = new byte[] { 10 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 45,
                Properties = new byte[] { 11 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 46,
                Properties = new byte[] { 12 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 47,
                Properties = new byte[] { 13 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 48,
                Properties = new byte[] { 14 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 49,
                Properties = new byte[] { 15 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
