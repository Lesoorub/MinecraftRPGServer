using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.blue_bed)]
    public class blue_bed : IBlockData
    {
        public short DefaultStateID => 1260;
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 841;
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
                Id = 1257,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1258,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1259,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1260,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1261,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1262,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1263,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1264,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1265,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1266,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1267,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1268,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1269,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1270,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1271,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1272,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
