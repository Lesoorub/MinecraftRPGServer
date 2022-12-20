using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.crimson_fence_gate)]
    public class crimson_fence_gate : IBlockData
    {
        public short DefaultStateID => 15516;
        public state DefaultState => States[7];
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 655;
        public MinecraftMaterial Material => MinecraftMaterial.nether_wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "in_wall", new List<string>() { "True", "False" } },
            { "open", new List<string>() { "True", "False" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15509,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15510,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15511,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15512,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15513,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15514,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15515,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15516,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15517,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15518,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15519,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15520,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15521,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15522,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15523,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15524,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15525,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15526,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15527,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15528,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15529,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15530,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15531,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15532,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15533,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15534,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15535,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15536,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15537,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15538,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15539,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15540,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
