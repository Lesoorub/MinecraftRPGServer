using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.warped_fence_gate)]
    public class warped_fence_gate : IBlockData
    {
        public short DefaultStateID => 15548;
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 656;
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
                Id = 15541,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15542,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15543,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15544,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15545,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15546,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15547,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15548,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15549,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15550,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15551,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15552,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15553,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15554,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15555,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15556,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15557,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15558,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15559,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15560,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15561,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15562,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15563,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15564,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15565,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15566,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15567,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15568,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15569,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15570,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15571,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15572,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
