using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.trapped_chest)]
    public class trapped_chest : IBlockData
    {
        public short DefaultStateID => 6829;
        public state DefaultState => States[1];
        public float Hardness => 2.5f;
        public float ExplosionResistance => 2.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 605;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "type", new List<string>() { "single", "left", "right" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6828,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6829,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6830,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 117,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6831,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 117,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6832,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = 120,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6833,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = 120,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6834,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6835,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6836,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 120,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6837,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 120,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6838,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = 117,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6839,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = 117,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6840,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6841,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6842,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 122,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6843,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 122,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6844,
                Properties = new byte[] { 2,2,0 },
                CollisionShape = 125,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6845,
                Properties = new byte[] { 2,2,1 },
                CollisionShape = 125,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6846,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6847,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6848,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 125,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6849,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 125,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6850,
                Properties = new byte[] { 3,2,0 },
                CollisionShape = 122,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6851,
                Properties = new byte[] { 3,2,1 },
                CollisionShape = 122,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
