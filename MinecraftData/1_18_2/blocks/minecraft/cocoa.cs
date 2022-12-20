using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cocoa)]
    public class cocoa : IBlockData
    {
        public short DefaultStateID => 5363;
        public state DefaultState => States[0];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 809;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "age", new List<string>() { "0", "1", "2" } },
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5363,
                Properties = new byte[] { 0,0 },
                CollisionShape = 374,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5364,
                Properties = new byte[] { 0,1 },
                CollisionShape = 375,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5365,
                Properties = new byte[] { 0,2 },
                CollisionShape = 376,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5366,
                Properties = new byte[] { 0,3 },
                CollisionShape = 377,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5367,
                Properties = new byte[] { 1,0 },
                CollisionShape = 378,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5368,
                Properties = new byte[] { 1,1 },
                CollisionShape = 379,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5369,
                Properties = new byte[] { 1,2 },
                CollisionShape = 380,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5370,
                Properties = new byte[] { 1,3 },
                CollisionShape = 381,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5371,
                Properties = new byte[] { 2,0 },
                CollisionShape = 382,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5372,
                Properties = new byte[] { 2,1 },
                CollisionShape = 383,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5373,
                Properties = new byte[] { 2,2 },
                CollisionShape = 384,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5374,
                Properties = new byte[] { 2,3 },
                CollisionShape = 385,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
