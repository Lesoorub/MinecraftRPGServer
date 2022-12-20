using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cyan_bed)]
    public class cyan_bed : IBlockData
    {
        public short DefaultStateID => 1228;
        public state DefaultState => States[3];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 839;
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
                Id = 1225,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1226,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1227,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1228,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1229,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1230,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1231,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1232,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1233,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1234,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1235,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1236,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1237,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1238,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1239,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1240,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
