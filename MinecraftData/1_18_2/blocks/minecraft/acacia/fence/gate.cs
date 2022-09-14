using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.acacia_fence_gate)]
    public class acacia_fence_gate : IBlockData
    {
        public short DefaultStateID => 8771;
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 653;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
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
                Id = 8764,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8765,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8766,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8767,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8768,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8769,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8770,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8771,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8772,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8773,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8774,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8775,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8776,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8777,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8778,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8779,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8780,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8781,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8782,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8783,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8784,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8785,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8786,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8787,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8788,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8789,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8790,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8791,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8792,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8793,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8794,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8795,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
