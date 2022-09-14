using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.skeleton_skull)]
    public class skeleton_skull : IBlockData
    {
        public short DefaultStateID => 6696;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 953;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "rotation", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6696,
                Properties = new byte[] { 0 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6697,
                Properties = new byte[] { 1 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6698,
                Properties = new byte[] { 2 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6699,
                Properties = new byte[] { 3 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6700,
                Properties = new byte[] { 4 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6701,
                Properties = new byte[] { 5 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6702,
                Properties = new byte[] { 6 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6703,
                Properties = new byte[] { 7 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6704,
                Properties = new byte[] { 8 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6705,
                Properties = new byte[] { 9 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6706,
                Properties = new byte[] { 10 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6707,
                Properties = new byte[] { 11 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6708,
                Properties = new byte[] { 12 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6709,
                Properties = new byte[] { 13 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6710,
                Properties = new byte[] { 14 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6711,
                Properties = new byte[] { 15 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
