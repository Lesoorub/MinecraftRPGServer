using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.comparator)]
    public class comparator : IBlockData
    {
        public short DefaultStateID => 6885;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 589;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "mode", new List<string>() { "compare", "subtract" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6884,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6885,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6886,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6887,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6888,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6889,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6890,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6891,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6892,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6893,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6894,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6895,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6896,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6897,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6898,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6899,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
