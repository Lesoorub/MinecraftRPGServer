using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.glass_pane)]
    public class glass_pane : IBlockData
    {
        public short DefaultStateID => 4835;
        public float Hardness => 0.3f;
        public float ExplosionResistance => 0.3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 297;
        public MinecraftMaterial Material => MinecraftMaterial.glass;
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
                Id = 4804,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 297,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4805,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 298,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4806,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 297,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4807,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 298,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4808,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 299,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4809,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 300,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4810,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 299,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4811,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 300,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4812,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 301,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4813,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 302,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4814,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 301,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4815,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 302,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4816,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 303,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4817,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 304,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4818,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 303,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4819,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 304,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4820,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 305,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4821,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 306,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4822,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 305,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4823,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 306,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4824,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 307,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4825,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 308,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4826,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 307,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4827,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 308,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4828,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 309,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4829,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 310,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4830,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 309,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4831,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 310,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4832,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 311,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4833,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 312,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4834,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 311,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4835,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 312,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
