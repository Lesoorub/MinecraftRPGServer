using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.bamboo)]
    public class bamboo : IBlockData
    {
        public short DefaultStateID => 9902;
        public state DefaultState => States[0];
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => true;
        public byte SoundGroup => 17;
        public short DroppedItem => 203;
        public MinecraftMaterial Material => MinecraftMaterial.bamboo;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "age", new List<string>() { "0", "1" } },
            { "leaves", new List<string>() { "none", "small", "large" } },
            { "stage", new List<string>() { "0", "1" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9902,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9903,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9904,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9905,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9906,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9907,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9908,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9909,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9910,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9911,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9912,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9913,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
