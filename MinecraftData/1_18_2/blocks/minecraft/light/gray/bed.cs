using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.light_gray_bed)]
    public class light_gray_bed : IBlockData
    {
        public short DefaultStateID => 1212;
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 838;
        public MinecraftMaterial Material => MinecraftMaterial.wool;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "occupied", new List<string>() { "True", "False" } },
            { "part", new List<string>() { "head", "foot" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1209,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1210,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1211,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1212,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1213,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1214,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1215,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1216,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1217,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1218,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1219,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1220,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1221,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1222,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1223,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1224,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
