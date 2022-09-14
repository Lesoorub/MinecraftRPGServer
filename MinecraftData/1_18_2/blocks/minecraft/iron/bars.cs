using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.iron_bars)]
    public class iron_bars : IBlockData
    {
        public short DefaultStateID => 4797;
        public float Hardness => 5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => true;
        public byte SoundGroup => 5;
        public short DroppedItem => 295;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "east", new List<string>() { "True", "False" } },
            { "north", new List<string>() { "True", "False" } },
            { "south", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } },
            { "west", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4766,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 297,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4767,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 298,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4768,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 297,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4769,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 298,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4770,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 299,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4771,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 300,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4772,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 299,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4773,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 300,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4774,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 301,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4775,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 302,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4776,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 301,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4777,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 302,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4778,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 303,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4779,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 304,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4780,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 303,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4781,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 304,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4782,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 305,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4783,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 306,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4784,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 305,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4785,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 306,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4786,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 307,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4787,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 308,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4788,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 307,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4789,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 308,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4790,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 309,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4791,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 310,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4792,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 309,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4793,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 310,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4794,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 311,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4795,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 312,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4796,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 311,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4797,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 312,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
