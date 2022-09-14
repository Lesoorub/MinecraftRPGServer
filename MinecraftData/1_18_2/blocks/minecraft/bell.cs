using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.bell)]
    public class bell : IBlockData
    {
        public short DefaultStateID => 15105;
        public float Hardness => 5f;
        public float ExplosionResistance => 5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 12;
        public short DroppedItem => 1051;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "attachment", new List<string>() { "floor", "ceiling", "single_wall", "double_wall" } },
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15104,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 709,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15105,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 709,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15106,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 709,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15107,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 709,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15108,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = 710,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15109,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = 710,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15110,
                Properties = new byte[] { 0,3,0 },
                CollisionShape = 710,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15111,
                Properties = new byte[] { 0,3,1 },
                CollisionShape = 710,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15112,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15113,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15114,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15115,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15116,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15117,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15118,
                Properties = new byte[] { 1,3,0 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15119,
                Properties = new byte[] { 1,3,1 },
                CollisionShape = 711,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15120,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 712,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15121,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 712,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15122,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 714,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15123,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 714,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15124,
                Properties = new byte[] { 2,2,0 },
                CollisionShape = 715,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15125,
                Properties = new byte[] { 2,2,1 },
                CollisionShape = 715,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15126,
                Properties = new byte[] { 2,3,0 },
                CollisionShape = 717,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15127,
                Properties = new byte[] { 2,3,1 },
                CollisionShape = 717,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15128,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 718,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15129,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 718,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15130,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 718,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15131,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 718,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15132,
                Properties = new byte[] { 3,2,0 },
                CollisionShape = 719,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15133,
                Properties = new byte[] { 3,2,1 },
                CollisionShape = 719,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15134,
                Properties = new byte[] { 3,3,0 },
                CollisionShape = 719,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15135,
                Properties = new byte[] { 3,3,1 },
                CollisionShape = 719,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
