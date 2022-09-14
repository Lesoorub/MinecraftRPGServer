using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.magenta_stained_glass_pane)]
    public class magenta_stained_glass_pane : IBlockData
    {
        public short DefaultStateID => 7176;
        public float Hardness => 0.3f;
        public float ExplosionResistance => 0.3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 418;
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
                Id = 7145,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 297,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7146,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 298,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7147,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 297,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7148,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 298,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7149,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 299,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7150,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 300,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7151,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 299,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7152,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 300,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7153,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 301,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7154,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 302,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7155,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 301,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7156,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 302,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7157,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 303,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7158,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 304,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7159,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 303,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7160,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 304,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7161,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 305,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7162,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 306,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7163,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 305,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7164,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 306,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7165,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 307,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7166,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 308,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7167,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 307,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7168,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 308,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7169,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 309,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7170,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 310,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7171,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 309,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7172,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 310,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7173,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 311,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7174,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 312,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7175,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 311,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7176,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 312,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
