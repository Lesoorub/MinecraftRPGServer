using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.pink_stained_glass_pane)]
    public class pink_stained_glass_pane : IBlockData
    {
        public short DefaultStateID => 7304;
        public float Hardness => 0.3f;
        public float ExplosionResistance => 0.3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 422;
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
                Id = 7273,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 297,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7274,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 298,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7275,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 297,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7276,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 298,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7277,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 299,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7278,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 300,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7279,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 299,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7280,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 300,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7281,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 301,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7282,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 302,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7283,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 301,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7284,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 302,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7285,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 303,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7286,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 304,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7287,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 303,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7288,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 304,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7289,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 305,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7290,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 306,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7291,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 305,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7292,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 306,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7293,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 307,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7294,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 308,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7295,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 307,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7296,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 308,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7297,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 309,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7298,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 310,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7299,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 309,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7300,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 310,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7301,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 311,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7302,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 312,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7303,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 311,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7304,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 312,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
