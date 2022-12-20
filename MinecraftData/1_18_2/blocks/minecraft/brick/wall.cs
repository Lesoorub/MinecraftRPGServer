using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.brick_wall)]
    public class brick_wall : IBlockData
    {
        public short DefaultStateID => 11120;
        public state DefaultState => States[3];
        public float Hardness => 2f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 327;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "east", new List<string>() { "none", "low", "tall" } },
            { "north", new List<string>() { "none", "low", "tall" } },
            { "south", new List<string>() { "none", "low", "tall" } },
            { "up", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } },
            { "west", new List<string>() { "none", "low", "tall" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 11117,
                Properties = new byte[] { 0,0,0,0,0,0 },
                CollisionShape = 391,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11118,
                Properties = new byte[] { 0,0,0,0,0,1 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11119,
                Properties = new byte[] { 0,0,0,0,0,2 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11120,
                Properties = new byte[] { 0,0,0,0,1,0 },
                CollisionShape = 391,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11121,
                Properties = new byte[] { 0,0,0,0,1,1 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11122,
                Properties = new byte[] { 0,0,0,0,1,2 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11123,
                Properties = new byte[] { 0,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11124,
                Properties = new byte[] { 0,0,0,1,0,1 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11125,
                Properties = new byte[] { 0,0,0,1,0,2 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11126,
                Properties = new byte[] { 0,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11127,
                Properties = new byte[] { 0,0,0,1,1,1 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11128,
                Properties = new byte[] { 0,0,0,1,1,2 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11129,
                Properties = new byte[] { 0,0,1,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11130,
                Properties = new byte[] { 0,0,1,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11131,
                Properties = new byte[] { 0,0,1,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11132,
                Properties = new byte[] { 0,0,1,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11133,
                Properties = new byte[] { 0,0,1,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11134,
                Properties = new byte[] { 0,0,1,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11135,
                Properties = new byte[] { 0,0,1,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11136,
                Properties = new byte[] { 0,0,1,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11137,
                Properties = new byte[] { 0,0,1,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11138,
                Properties = new byte[] { 0,0,1,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11139,
                Properties = new byte[] { 0,0,1,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11140,
                Properties = new byte[] { 0,0,1,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11141,
                Properties = new byte[] { 0,0,2,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11142,
                Properties = new byte[] { 0,0,2,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11143,
                Properties = new byte[] { 0,0,2,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11144,
                Properties = new byte[] { 0,0,2,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11145,
                Properties = new byte[] { 0,0,2,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11146,
                Properties = new byte[] { 0,0,2,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11147,
                Properties = new byte[] { 0,0,2,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11148,
                Properties = new byte[] { 0,0,2,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11149,
                Properties = new byte[] { 0,0,2,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11150,
                Properties = new byte[] { 0,0,2,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11151,
                Properties = new byte[] { 0,0,2,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11152,
                Properties = new byte[] { 0,0,2,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11153,
                Properties = new byte[] { 0,1,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11154,
                Properties = new byte[] { 0,1,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11155,
                Properties = new byte[] { 0,1,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11156,
                Properties = new byte[] { 0,1,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11157,
                Properties = new byte[] { 0,1,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11158,
                Properties = new byte[] { 0,1,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11159,
                Properties = new byte[] { 0,1,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11160,
                Properties = new byte[] { 0,1,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11161,
                Properties = new byte[] { 0,1,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11162,
                Properties = new byte[] { 0,1,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11163,
                Properties = new byte[] { 0,1,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11164,
                Properties = new byte[] { 0,1,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11165,
                Properties = new byte[] { 0,1,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11166,
                Properties = new byte[] { 0,1,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11167,
                Properties = new byte[] { 0,1,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11168,
                Properties = new byte[] { 0,1,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11169,
                Properties = new byte[] { 0,1,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11170,
                Properties = new byte[] { 0,1,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11171,
                Properties = new byte[] { 0,1,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11172,
                Properties = new byte[] { 0,1,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11173,
                Properties = new byte[] { 0,1,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11174,
                Properties = new byte[] { 0,1,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11175,
                Properties = new byte[] { 0,1,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11176,
                Properties = new byte[] { 0,1,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11177,
                Properties = new byte[] { 0,1,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11178,
                Properties = new byte[] { 0,1,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11179,
                Properties = new byte[] { 0,1,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11180,
                Properties = new byte[] { 0,1,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11181,
                Properties = new byte[] { 0,1,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11182,
                Properties = new byte[] { 0,1,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11183,
                Properties = new byte[] { 0,1,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11184,
                Properties = new byte[] { 0,1,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11185,
                Properties = new byte[] { 0,1,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11186,
                Properties = new byte[] { 0,1,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11187,
                Properties = new byte[] { 0,1,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11188,
                Properties = new byte[] { 0,1,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11189,
                Properties = new byte[] { 0,2,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11190,
                Properties = new byte[] { 0,2,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11191,
                Properties = new byte[] { 0,2,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11192,
                Properties = new byte[] { 0,2,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11193,
                Properties = new byte[] { 0,2,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11194,
                Properties = new byte[] { 0,2,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11195,
                Properties = new byte[] { 0,2,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11196,
                Properties = new byte[] { 0,2,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11197,
                Properties = new byte[] { 0,2,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11198,
                Properties = new byte[] { 0,2,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11199,
                Properties = new byte[] { 0,2,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11200,
                Properties = new byte[] { 0,2,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11201,
                Properties = new byte[] { 0,2,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11202,
                Properties = new byte[] { 0,2,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11203,
                Properties = new byte[] { 0,2,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11204,
                Properties = new byte[] { 0,2,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11205,
                Properties = new byte[] { 0,2,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11206,
                Properties = new byte[] { 0,2,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11207,
                Properties = new byte[] { 0,2,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11208,
                Properties = new byte[] { 0,2,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11209,
                Properties = new byte[] { 0,2,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11210,
                Properties = new byte[] { 0,2,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11211,
                Properties = new byte[] { 0,2,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11212,
                Properties = new byte[] { 0,2,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11213,
                Properties = new byte[] { 0,2,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11214,
                Properties = new byte[] { 0,2,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11215,
                Properties = new byte[] { 0,2,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11216,
                Properties = new byte[] { 0,2,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11217,
                Properties = new byte[] { 0,2,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11218,
                Properties = new byte[] { 0,2,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11219,
                Properties = new byte[] { 0,2,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11220,
                Properties = new byte[] { 0,2,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11221,
                Properties = new byte[] { 0,2,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11222,
                Properties = new byte[] { 0,2,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11223,
                Properties = new byte[] { 0,2,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11224,
                Properties = new byte[] { 0,2,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11225,
                Properties = new byte[] { 1,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11226,
                Properties = new byte[] { 1,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11227,
                Properties = new byte[] { 1,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11228,
                Properties = new byte[] { 1,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11229,
                Properties = new byte[] { 1,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11230,
                Properties = new byte[] { 1,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11231,
                Properties = new byte[] { 1,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11232,
                Properties = new byte[] { 1,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11233,
                Properties = new byte[] { 1,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11234,
                Properties = new byte[] { 1,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11235,
                Properties = new byte[] { 1,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11236,
                Properties = new byte[] { 1,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11237,
                Properties = new byte[] { 1,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11238,
                Properties = new byte[] { 1,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11239,
                Properties = new byte[] { 1,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11240,
                Properties = new byte[] { 1,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11241,
                Properties = new byte[] { 1,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11242,
                Properties = new byte[] { 1,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11243,
                Properties = new byte[] { 1,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11244,
                Properties = new byte[] { 1,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11245,
                Properties = new byte[] { 1,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11246,
                Properties = new byte[] { 1,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11247,
                Properties = new byte[] { 1,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11248,
                Properties = new byte[] { 1,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11249,
                Properties = new byte[] { 1,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11250,
                Properties = new byte[] { 1,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11251,
                Properties = new byte[] { 1,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11252,
                Properties = new byte[] { 1,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11253,
                Properties = new byte[] { 1,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11254,
                Properties = new byte[] { 1,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11255,
                Properties = new byte[] { 1,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11256,
                Properties = new byte[] { 1,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11257,
                Properties = new byte[] { 1,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11258,
                Properties = new byte[] { 1,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11259,
                Properties = new byte[] { 1,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11260,
                Properties = new byte[] { 1,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11261,
                Properties = new byte[] { 1,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11262,
                Properties = new byte[] { 1,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11263,
                Properties = new byte[] { 1,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11264,
                Properties = new byte[] { 1,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11265,
                Properties = new byte[] { 1,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11266,
                Properties = new byte[] { 1,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11267,
                Properties = new byte[] { 1,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11268,
                Properties = new byte[] { 1,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11269,
                Properties = new byte[] { 1,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11270,
                Properties = new byte[] { 1,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11271,
                Properties = new byte[] { 1,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11272,
                Properties = new byte[] { 1,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11273,
                Properties = new byte[] { 1,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11274,
                Properties = new byte[] { 1,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11275,
                Properties = new byte[] { 1,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11276,
                Properties = new byte[] { 1,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11277,
                Properties = new byte[] { 1,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11278,
                Properties = new byte[] { 1,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11279,
                Properties = new byte[] { 1,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11280,
                Properties = new byte[] { 1,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11281,
                Properties = new byte[] { 1,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11282,
                Properties = new byte[] { 1,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11283,
                Properties = new byte[] { 1,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11284,
                Properties = new byte[] { 1,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11285,
                Properties = new byte[] { 1,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11286,
                Properties = new byte[] { 1,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11287,
                Properties = new byte[] { 1,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11288,
                Properties = new byte[] { 1,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11289,
                Properties = new byte[] { 1,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11290,
                Properties = new byte[] { 1,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11291,
                Properties = new byte[] { 1,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11292,
                Properties = new byte[] { 1,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11293,
                Properties = new byte[] { 1,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11294,
                Properties = new byte[] { 1,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11295,
                Properties = new byte[] { 1,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11296,
                Properties = new byte[] { 1,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11297,
                Properties = new byte[] { 1,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11298,
                Properties = new byte[] { 1,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11299,
                Properties = new byte[] { 1,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11300,
                Properties = new byte[] { 1,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11301,
                Properties = new byte[] { 1,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11302,
                Properties = new byte[] { 1,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11303,
                Properties = new byte[] { 1,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11304,
                Properties = new byte[] { 1,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11305,
                Properties = new byte[] { 1,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11306,
                Properties = new byte[] { 1,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11307,
                Properties = new byte[] { 1,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11308,
                Properties = new byte[] { 1,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11309,
                Properties = new byte[] { 1,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11310,
                Properties = new byte[] { 1,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11311,
                Properties = new byte[] { 1,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11312,
                Properties = new byte[] { 1,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11313,
                Properties = new byte[] { 1,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11314,
                Properties = new byte[] { 1,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11315,
                Properties = new byte[] { 1,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11316,
                Properties = new byte[] { 1,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11317,
                Properties = new byte[] { 1,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11318,
                Properties = new byte[] { 1,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11319,
                Properties = new byte[] { 1,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11320,
                Properties = new byte[] { 1,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11321,
                Properties = new byte[] { 1,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11322,
                Properties = new byte[] { 1,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11323,
                Properties = new byte[] { 1,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11324,
                Properties = new byte[] { 1,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11325,
                Properties = new byte[] { 1,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11326,
                Properties = new byte[] { 1,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11327,
                Properties = new byte[] { 1,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11328,
                Properties = new byte[] { 1,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11329,
                Properties = new byte[] { 1,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11330,
                Properties = new byte[] { 1,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11331,
                Properties = new byte[] { 1,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11332,
                Properties = new byte[] { 1,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11333,
                Properties = new byte[] { 2,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11334,
                Properties = new byte[] { 2,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11335,
                Properties = new byte[] { 2,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11336,
                Properties = new byte[] { 2,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11337,
                Properties = new byte[] { 2,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11338,
                Properties = new byte[] { 2,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11339,
                Properties = new byte[] { 2,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11340,
                Properties = new byte[] { 2,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11341,
                Properties = new byte[] { 2,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11342,
                Properties = new byte[] { 2,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11343,
                Properties = new byte[] { 2,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11344,
                Properties = new byte[] { 2,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11345,
                Properties = new byte[] { 2,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11346,
                Properties = new byte[] { 2,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11347,
                Properties = new byte[] { 2,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11348,
                Properties = new byte[] { 2,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11349,
                Properties = new byte[] { 2,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11350,
                Properties = new byte[] { 2,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11351,
                Properties = new byte[] { 2,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11352,
                Properties = new byte[] { 2,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11353,
                Properties = new byte[] { 2,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11354,
                Properties = new byte[] { 2,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11355,
                Properties = new byte[] { 2,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11356,
                Properties = new byte[] { 2,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11357,
                Properties = new byte[] { 2,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11358,
                Properties = new byte[] { 2,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11359,
                Properties = new byte[] { 2,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11360,
                Properties = new byte[] { 2,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11361,
                Properties = new byte[] { 2,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11362,
                Properties = new byte[] { 2,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11363,
                Properties = new byte[] { 2,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11364,
                Properties = new byte[] { 2,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11365,
                Properties = new byte[] { 2,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11366,
                Properties = new byte[] { 2,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11367,
                Properties = new byte[] { 2,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11368,
                Properties = new byte[] { 2,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11369,
                Properties = new byte[] { 2,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11370,
                Properties = new byte[] { 2,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11371,
                Properties = new byte[] { 2,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11372,
                Properties = new byte[] { 2,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11373,
                Properties = new byte[] { 2,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11374,
                Properties = new byte[] { 2,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11375,
                Properties = new byte[] { 2,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11376,
                Properties = new byte[] { 2,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11377,
                Properties = new byte[] { 2,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11378,
                Properties = new byte[] { 2,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11379,
                Properties = new byte[] { 2,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11380,
                Properties = new byte[] { 2,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11381,
                Properties = new byte[] { 2,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11382,
                Properties = new byte[] { 2,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11383,
                Properties = new byte[] { 2,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11384,
                Properties = new byte[] { 2,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11385,
                Properties = new byte[] { 2,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11386,
                Properties = new byte[] { 2,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11387,
                Properties = new byte[] { 2,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11388,
                Properties = new byte[] { 2,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11389,
                Properties = new byte[] { 2,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11390,
                Properties = new byte[] { 2,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11391,
                Properties = new byte[] { 2,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11392,
                Properties = new byte[] { 2,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11393,
                Properties = new byte[] { 2,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11394,
                Properties = new byte[] { 2,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11395,
                Properties = new byte[] { 2,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11396,
                Properties = new byte[] { 2,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11397,
                Properties = new byte[] { 2,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11398,
                Properties = new byte[] { 2,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11399,
                Properties = new byte[] { 2,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11400,
                Properties = new byte[] { 2,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11401,
                Properties = new byte[] { 2,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11402,
                Properties = new byte[] { 2,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11403,
                Properties = new byte[] { 2,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11404,
                Properties = new byte[] { 2,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11405,
                Properties = new byte[] { 2,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11406,
                Properties = new byte[] { 2,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11407,
                Properties = new byte[] { 2,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11408,
                Properties = new byte[] { 2,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11409,
                Properties = new byte[] { 2,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11410,
                Properties = new byte[] { 2,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11411,
                Properties = new byte[] { 2,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11412,
                Properties = new byte[] { 2,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11413,
                Properties = new byte[] { 2,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11414,
                Properties = new byte[] { 2,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11415,
                Properties = new byte[] { 2,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11416,
                Properties = new byte[] { 2,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11417,
                Properties = new byte[] { 2,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11418,
                Properties = new byte[] { 2,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11419,
                Properties = new byte[] { 2,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11420,
                Properties = new byte[] { 2,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11421,
                Properties = new byte[] { 2,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11422,
                Properties = new byte[] { 2,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11423,
                Properties = new byte[] { 2,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11424,
                Properties = new byte[] { 2,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11425,
                Properties = new byte[] { 2,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11426,
                Properties = new byte[] { 2,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11427,
                Properties = new byte[] { 2,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11428,
                Properties = new byte[] { 2,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11429,
                Properties = new byte[] { 2,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11430,
                Properties = new byte[] { 2,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11431,
                Properties = new byte[] { 2,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11432,
                Properties = new byte[] { 2,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11433,
                Properties = new byte[] { 2,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11434,
                Properties = new byte[] { 2,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11435,
                Properties = new byte[] { 2,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11436,
                Properties = new byte[] { 2,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11437,
                Properties = new byte[] { 2,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11438,
                Properties = new byte[] { 2,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11439,
                Properties = new byte[] { 2,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 11440,
                Properties = new byte[] { 2,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
