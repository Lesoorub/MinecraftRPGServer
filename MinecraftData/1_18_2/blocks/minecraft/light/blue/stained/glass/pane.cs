using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.light_blue_stained_glass_pane)]
    public class light_blue_stained_glass_pane : IBlockData
    {
        public short DefaultStateID => 7208;
        public state DefaultState => States[31];
        public float Hardness => 0.3f;
        public float ExplosionResistance => 0.3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 419;
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
                Id = 7177,
                Properties = new byte[] { 0,0,0,0,0 },
                CollisionShape = 297,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7178,
                Properties = new byte[] { 0,0,0,0,1 },
                CollisionShape = 298,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7179,
                Properties = new byte[] { 0,0,0,1,0 },
                CollisionShape = 297,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7180,
                Properties = new byte[] { 0,0,0,1,1 },
                CollisionShape = 298,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7181,
                Properties = new byte[] { 0,0,1,0,0 },
                CollisionShape = 299,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7182,
                Properties = new byte[] { 0,0,1,0,1 },
                CollisionShape = 300,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7183,
                Properties = new byte[] { 0,0,1,1,0 },
                CollisionShape = 299,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7184,
                Properties = new byte[] { 0,0,1,1,1 },
                CollisionShape = 300,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7185,
                Properties = new byte[] { 0,1,0,0,0 },
                CollisionShape = 301,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7186,
                Properties = new byte[] { 0,1,0,0,1 },
                CollisionShape = 302,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7187,
                Properties = new byte[] { 0,1,0,1,0 },
                CollisionShape = 301,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7188,
                Properties = new byte[] { 0,1,0,1,1 },
                CollisionShape = 302,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7189,
                Properties = new byte[] { 0,1,1,0,0 },
                CollisionShape = 303,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7190,
                Properties = new byte[] { 0,1,1,0,1 },
                CollisionShape = 304,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7191,
                Properties = new byte[] { 0,1,1,1,0 },
                CollisionShape = 303,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7192,
                Properties = new byte[] { 0,1,1,1,1 },
                CollisionShape = 304,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7193,
                Properties = new byte[] { 1,0,0,0,0 },
                CollisionShape = 305,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7194,
                Properties = new byte[] { 1,0,0,0,1 },
                CollisionShape = 306,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7195,
                Properties = new byte[] { 1,0,0,1,0 },
                CollisionShape = 305,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7196,
                Properties = new byte[] { 1,0,0,1,1 },
                CollisionShape = 306,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7197,
                Properties = new byte[] { 1,0,1,0,0 },
                CollisionShape = 307,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7198,
                Properties = new byte[] { 1,0,1,0,1 },
                CollisionShape = 308,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7199,
                Properties = new byte[] { 1,0,1,1,0 },
                CollisionShape = 307,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7200,
                Properties = new byte[] { 1,0,1,1,1 },
                CollisionShape = 308,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7201,
                Properties = new byte[] { 1,1,0,0,0 },
                CollisionShape = 309,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7202,
                Properties = new byte[] { 1,1,0,0,1 },
                CollisionShape = 310,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7203,
                Properties = new byte[] { 1,1,0,1,0 },
                CollisionShape = 309,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7204,
                Properties = new byte[] { 1,1,0,1,1 },
                CollisionShape = 310,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7205,
                Properties = new byte[] { 1,1,1,0,0 },
                CollisionShape = 311,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7206,
                Properties = new byte[] { 1,1,1,0,1 },
                CollisionShape = 312,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7207,
                Properties = new byte[] { 1,1,1,1,0 },
                CollisionShape = 311,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 7208,
                Properties = new byte[] { 1,1,1,1,1 },
                CollisionShape = 312,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
