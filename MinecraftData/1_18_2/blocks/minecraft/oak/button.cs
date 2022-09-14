using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.oak_button)]
    public class oak_button : IBlockData
    {
        public short DefaultStateID => 6561;
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 611;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "face", new List<string>() { "floor", "wall", "ceiling" } },
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6552,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6553,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6554,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6555,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6556,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6557,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6558,
                Properties = new byte[] { 0,3,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6559,
                Properties = new byte[] { 0,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6560,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6561,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6562,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6563,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6564,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6565,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6566,
                Properties = new byte[] { 1,3,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6567,
                Properties = new byte[] { 1,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6568,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6569,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6570,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6571,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6572,
                Properties = new byte[] { 2,2,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6573,
                Properties = new byte[] { 2,2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6574,
                Properties = new byte[] { 2,3,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6575,
                Properties = new byte[] { 2,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
