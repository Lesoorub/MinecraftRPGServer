using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.daylight_detector)]
    public class daylight_detector : IBlockData
    {
        public short DefaultStateID => 6916;
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 602;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "inverted", new List<string>() { "True", "False" } },
            { "power", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6900,
                Properties = new byte[] { 0,0 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6901,
                Properties = new byte[] { 0,1 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6902,
                Properties = new byte[] { 0,2 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6903,
                Properties = new byte[] { 0,3 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6904,
                Properties = new byte[] { 0,4 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6905,
                Properties = new byte[] { 0,5 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6906,
                Properties = new byte[] { 0,6 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6907,
                Properties = new byte[] { 0,7 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6908,
                Properties = new byte[] { 0,8 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6909,
                Properties = new byte[] { 0,9 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6910,
                Properties = new byte[] { 0,10 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6911,
                Properties = new byte[] { 0,11 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6912,
                Properties = new byte[] { 0,12 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6913,
                Properties = new byte[] { 0,13 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6914,
                Properties = new byte[] { 0,14 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6915,
                Properties = new byte[] { 0,15 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6916,
                Properties = new byte[] { 1,0 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6917,
                Properties = new byte[] { 1,1 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6918,
                Properties = new byte[] { 1,2 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6919,
                Properties = new byte[] { 1,3 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6920,
                Properties = new byte[] { 1,4 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6921,
                Properties = new byte[] { 1,5 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6922,
                Properties = new byte[] { 1,6 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6923,
                Properties = new byte[] { 1,7 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6924,
                Properties = new byte[] { 1,8 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6925,
                Properties = new byte[] { 1,9 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6926,
                Properties = new byte[] { 1,10 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6927,
                Properties = new byte[] { 1,11 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6928,
                Properties = new byte[] { 1,12 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6929,
                Properties = new byte[] { 1,13 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6930,
                Properties = new byte[] { 1,14 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 6931,
                Properties = new byte[] { 1,15 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
