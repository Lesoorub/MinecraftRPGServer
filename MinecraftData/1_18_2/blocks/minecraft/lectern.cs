using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.lectern)]
    public class lectern : IBlockData
    {
        public short DefaultStateID => 15086;
        public float Hardness => 2.5f;
        public float ExplosionResistance => 2.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 598;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "has_book", new List<string>() { "True", "False" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15083,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15084,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15085,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15086,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15087,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15088,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15089,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15090,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15091,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15092,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15093,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15094,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15095,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15096,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15097,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15098,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 704,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
