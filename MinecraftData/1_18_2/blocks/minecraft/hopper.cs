using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.hopper)]
    public class hopper : IBlockData
    {
        public short DefaultStateID => 6934;
        public state DefaultState => States[0];
        public float Hardness => 3f;
        public float ExplosionResistance => 4.8f;
        public bool IsTransparent => true;
        public byte SoundGroup => 5;
        public short DroppedItem => 595;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "enabled", new List<string>() { "True", "False" } },
            { "facing", new List<string>() { "down", "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6934,
                Properties = new byte[] { 0,0 },
                CollisionShape = 597,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6935,
                Properties = new byte[] { 0,1 },
                CollisionShape = 598,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6936,
                Properties = new byte[] { 0,2 },
                CollisionShape = 599,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6937,
                Properties = new byte[] { 0,3 },
                CollisionShape = 600,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6938,
                Properties = new byte[] { 0,4 },
                CollisionShape = 601,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6939,
                Properties = new byte[] { 1,0 },
                CollisionShape = 597,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6940,
                Properties = new byte[] { 1,1 },
                CollisionShape = 598,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6941,
                Properties = new byte[] { 1,2 },
                CollisionShape = 599,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6942,
                Properties = new byte[] { 1,3 },
                CollisionShape = 600,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6943,
                Properties = new byte[] { 1,4 },
                CollisionShape = 601,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
