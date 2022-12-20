using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.crimson_fence)]
    public class crimson_fence : IBlockData
    {
        public short DefaultStateID => 15348;
        public state DefaultState => States[31];
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 263;
        public MinecraftMaterial Material => MinecraftMaterial.nether_wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "east", new List<string>() { "True", "False" } },
            { "north", new List<string>() { "True", "False" } },
            { "south", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } },
            { "west", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15317,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 249,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15318,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 253,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15319,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 249,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15320,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 253,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15321,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 255,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15322,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 257,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15323,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 255,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15324,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 257,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15325,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 259,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15326,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 261,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15327,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 259,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15328,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 261,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15329,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 263,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15330,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 265,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15331,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15332,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 265,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15333,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 267,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15334,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 269,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15335,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 267,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15336,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15337,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 271,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15338,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 273,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15339,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 271,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15340,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 273,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15341,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 275,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15342,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 277,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15343,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 275,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15344,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 277,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15345,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 279,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15346,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 281,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15347,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 279,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15348,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 281,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
