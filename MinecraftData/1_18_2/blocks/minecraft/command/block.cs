using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.command_block)]
    public class command_block : IBlockData
    {
        public short DefaultStateID => 5856;
        public float Hardness => -1f;
        public float ExplosionResistance => 3600000f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 323;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "conditional", new List<string>() { "True", "False" } },
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5850,
                Properties = new byte[] { 0,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5851,
                Properties = new byte[] { 0,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5852,
                Properties = new byte[] { 0,2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5853,
                Properties = new byte[] { 0,3 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5854,
                Properties = new byte[] { 0,4 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5855,
                Properties = new byte[] { 0,5 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5856,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5857,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5858,
                Properties = new byte[] { 1,2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5859,
                Properties = new byte[] { 1,3 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5860,
                Properties = new byte[] { 1,4 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5861,
                Properties = new byte[] { 1,5 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
