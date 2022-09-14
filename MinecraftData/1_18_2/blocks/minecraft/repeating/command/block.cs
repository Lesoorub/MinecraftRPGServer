using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.repeating_command_block)]
    public class repeating_command_block : IBlockData
    {
        public short DefaultStateID => 9481;
        public float Hardness => -1f;
        public float ExplosionResistance => 3600000f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 443;
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
                Id = 9475,
                Properties = new byte[] { 0,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9476,
                Properties = new byte[] { 0,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9477,
                Properties = new byte[] { 0,2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9478,
                Properties = new byte[] { 0,3 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9479,
                Properties = new byte[] { 0,4 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9480,
                Properties = new byte[] { 0,5 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9481,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9482,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9483,
                Properties = new byte[] { 1,2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9484,
                Properties = new byte[] { 1,3 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9485,
                Properties = new byte[] { 1,4 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9486,
                Properties = new byte[] { 1,5 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
