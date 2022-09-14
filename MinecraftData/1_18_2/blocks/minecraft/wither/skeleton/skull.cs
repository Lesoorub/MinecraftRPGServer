using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.wither_skeleton_skull)]
    public class wither_skeleton_skull : IBlockData
    {
        public short DefaultStateID => 6716;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 954;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "rotation", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6716,
                Properties = new byte[] { 0 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6717,
                Properties = new byte[] { 1 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6718,
                Properties = new byte[] { 2 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6719,
                Properties = new byte[] { 3 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6720,
                Properties = new byte[] { 4 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6721,
                Properties = new byte[] { 5 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6722,
                Properties = new byte[] { 6 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6723,
                Properties = new byte[] { 7 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6724,
                Properties = new byte[] { 8 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6725,
                Properties = new byte[] { 9 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6726,
                Properties = new byte[] { 10 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6727,
                Properties = new byte[] { 11 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6728,
                Properties = new byte[] { 12 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6729,
                Properties = new byte[] { 13 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6730,
                Properties = new byte[] { 14 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6731,
                Properties = new byte[] { 15 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
