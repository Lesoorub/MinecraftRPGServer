using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.green_bed)]
    public class green_bed : IBlockData
    {
        public short DefaultStateID => 1292;
        public state DefaultState => States[3];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 843;
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
                Id = 1289,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1290,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1291,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1292,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1293,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1294,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1295,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1296,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1297,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1298,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1299,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1300,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1301,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1302,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1303,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1304,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
