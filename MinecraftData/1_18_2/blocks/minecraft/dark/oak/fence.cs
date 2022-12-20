using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dark_oak_fence)]
    public class dark_oak_fence : IBlockData
    {
        public short DefaultStateID => 8987;
        public state DefaultState => States[31];
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 262;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
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
                Id = 8956,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 249,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8957,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 253,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8958,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 249,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8959,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 253,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8960,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 255,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8961,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 257,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8962,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 255,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8963,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 257,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8964,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 259,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8965,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 261,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8966,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 259,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8967,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 261,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8968,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 263,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8969,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 265,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8970,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8971,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 265,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8972,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 267,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8973,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 269,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8974,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 267,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8975,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8976,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 271,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8977,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 273,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8978,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 271,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8979,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 273,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8980,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 275,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8981,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 277,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8982,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 275,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8983,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 277,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8984,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 279,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8985,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 281,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8986,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 279,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8987,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 281,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
