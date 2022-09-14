using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dragon_head)]
    public class dragon_head : IBlockData
    {
        public short DefaultStateID => 6796;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 958;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "rotation", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6796,
                Properties = new byte[] { 0 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6797,
                Properties = new byte[] { 1 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6798,
                Properties = new byte[] { 2 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6799,
                Properties = new byte[] { 3 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6800,
                Properties = new byte[] { 4 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6801,
                Properties = new byte[] { 5 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6802,
                Properties = new byte[] { 6 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6803,
                Properties = new byte[] { 7 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6804,
                Properties = new byte[] { 8 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6805,
                Properties = new byte[] { 9 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6806,
                Properties = new byte[] { 10 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6807,
                Properties = new byte[] { 11 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6808,
                Properties = new byte[] { 12 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6809,
                Properties = new byte[] { 13 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6810,
                Properties = new byte[] { 14 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6811,
                Properties = new byte[] { 15 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
