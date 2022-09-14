using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.creeper_head)]
    public class creeper_head : IBlockData
    {
        public short DefaultStateID => 6776;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 957;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "rotation", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6776,
                Properties = new byte[] { 0 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6777,
                Properties = new byte[] { 1 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6778,
                Properties = new byte[] { 2 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6779,
                Properties = new byte[] { 3 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6780,
                Properties = new byte[] { 4 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6781,
                Properties = new byte[] { 5 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6782,
                Properties = new byte[] { 6 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6783,
                Properties = new byte[] { 7 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6784,
                Properties = new byte[] { 8 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6785,
                Properties = new byte[] { 9 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6786,
                Properties = new byte[] { 10 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6787,
                Properties = new byte[] { 11 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6788,
                Properties = new byte[] { 12 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6789,
                Properties = new byte[] { 13 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6790,
                Properties = new byte[] { 14 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6791,
                Properties = new byte[] { 15 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
