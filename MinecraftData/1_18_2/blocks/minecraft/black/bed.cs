using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.black_bed)]
    public class black_bed : IBlockData
    {
        public short DefaultStateID => 1324;
        public state DefaultState => States[3];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 845;
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
                Id = 1321,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1322,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1323,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1324,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1325,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1326,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1327,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 3,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1328,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 2,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1329,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1330,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1331,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1332,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1333,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1334,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1335,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 5,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1336,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 4,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
