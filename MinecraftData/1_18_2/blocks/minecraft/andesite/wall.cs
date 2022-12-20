using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.andesite_wall)]
    public class andesite_wall : IBlockData
    {
        public short DefaultStateID => 13388;
        public state DefaultState => States[3];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 334;
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
                Id = 13385,
                Properties = new byte[] { 0,0,0,0,0,0 },
                CollisionShape = 391,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13386,
                Properties = new byte[] { 0,0,0,0,0,1 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13387,
                Properties = new byte[] { 0,0,0,0,0,2 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13388,
                Properties = new byte[] { 0,0,0,0,1,0 },
                CollisionShape = 391,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13389,
                Properties = new byte[] { 0,0,0,0,1,1 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13390,
                Properties = new byte[] { 0,0,0,0,1,2 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13391,
                Properties = new byte[] { 0,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13392,
                Properties = new byte[] { 0,0,0,1,0,1 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13393,
                Properties = new byte[] { 0,0,0,1,0,2 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13394,
                Properties = new byte[] { 0,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13395,
                Properties = new byte[] { 0,0,0,1,1,1 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13396,
                Properties = new byte[] { 0,0,0,1,1,2 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13397,
                Properties = new byte[] { 0,0,1,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13398,
                Properties = new byte[] { 0,0,1,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13399,
                Properties = new byte[] { 0,0,1,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13400,
                Properties = new byte[] { 0,0,1,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13401,
                Properties = new byte[] { 0,0,1,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13402,
                Properties = new byte[] { 0,0,1,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13403,
                Properties = new byte[] { 0,0,1,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13404,
                Properties = new byte[] { 0,0,1,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13405,
                Properties = new byte[] { 0,0,1,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13406,
                Properties = new byte[] { 0,0,1,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13407,
                Properties = new byte[] { 0,0,1,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13408,
                Properties = new byte[] { 0,0,1,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13409,
                Properties = new byte[] { 0,0,2,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13410,
                Properties = new byte[] { 0,0,2,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13411,
                Properties = new byte[] { 0,0,2,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13412,
                Properties = new byte[] { 0,0,2,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13413,
                Properties = new byte[] { 0,0,2,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13414,
                Properties = new byte[] { 0,0,2,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13415,
                Properties = new byte[] { 0,0,2,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13416,
                Properties = new byte[] { 0,0,2,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13417,
                Properties = new byte[] { 0,0,2,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13418,
                Properties = new byte[] { 0,0,2,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13419,
                Properties = new byte[] { 0,0,2,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13420,
                Properties = new byte[] { 0,0,2,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13421,
                Properties = new byte[] { 0,1,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13422,
                Properties = new byte[] { 0,1,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13423,
                Properties = new byte[] { 0,1,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13424,
                Properties = new byte[] { 0,1,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13425,
                Properties = new byte[] { 0,1,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13426,
                Properties = new byte[] { 0,1,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13427,
                Properties = new byte[] { 0,1,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13428,
                Properties = new byte[] { 0,1,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13429,
                Properties = new byte[] { 0,1,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13430,
                Properties = new byte[] { 0,1,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13431,
                Properties = new byte[] { 0,1,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13432,
                Properties = new byte[] { 0,1,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13433,
                Properties = new byte[] { 0,1,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13434,
                Properties = new byte[] { 0,1,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13435,
                Properties = new byte[] { 0,1,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13436,
                Properties = new byte[] { 0,1,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13437,
                Properties = new byte[] { 0,1,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13438,
                Properties = new byte[] { 0,1,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13439,
                Properties = new byte[] { 0,1,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13440,
                Properties = new byte[] { 0,1,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13441,
                Properties = new byte[] { 0,1,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13442,
                Properties = new byte[] { 0,1,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13443,
                Properties = new byte[] { 0,1,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13444,
                Properties = new byte[] { 0,1,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13445,
                Properties = new byte[] { 0,1,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13446,
                Properties = new byte[] { 0,1,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13447,
                Properties = new byte[] { 0,1,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13448,
                Properties = new byte[] { 0,1,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13449,
                Properties = new byte[] { 0,1,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13450,
                Properties = new byte[] { 0,1,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13451,
                Properties = new byte[] { 0,1,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13452,
                Properties = new byte[] { 0,1,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13453,
                Properties = new byte[] { 0,1,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13454,
                Properties = new byte[] { 0,1,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13455,
                Properties = new byte[] { 0,1,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13456,
                Properties = new byte[] { 0,1,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13457,
                Properties = new byte[] { 0,2,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13458,
                Properties = new byte[] { 0,2,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13459,
                Properties = new byte[] { 0,2,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13460,
                Properties = new byte[] { 0,2,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13461,
                Properties = new byte[] { 0,2,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13462,
                Properties = new byte[] { 0,2,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13463,
                Properties = new byte[] { 0,2,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13464,
                Properties = new byte[] { 0,2,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13465,
                Properties = new byte[] { 0,2,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13466,
                Properties = new byte[] { 0,2,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13467,
                Properties = new byte[] { 0,2,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13468,
                Properties = new byte[] { 0,2,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13469,
                Properties = new byte[] { 0,2,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13470,
                Properties = new byte[] { 0,2,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13471,
                Properties = new byte[] { 0,2,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13472,
                Properties = new byte[] { 0,2,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13473,
                Properties = new byte[] { 0,2,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13474,
                Properties = new byte[] { 0,2,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13475,
                Properties = new byte[] { 0,2,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13476,
                Properties = new byte[] { 0,2,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13477,
                Properties = new byte[] { 0,2,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13478,
                Properties = new byte[] { 0,2,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13479,
                Properties = new byte[] { 0,2,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13480,
                Properties = new byte[] { 0,2,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13481,
                Properties = new byte[] { 0,2,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13482,
                Properties = new byte[] { 0,2,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13483,
                Properties = new byte[] { 0,2,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13484,
                Properties = new byte[] { 0,2,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13485,
                Properties = new byte[] { 0,2,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13486,
                Properties = new byte[] { 0,2,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13487,
                Properties = new byte[] { 0,2,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13488,
                Properties = new byte[] { 0,2,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13489,
                Properties = new byte[] { 0,2,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13490,
                Properties = new byte[] { 0,2,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13491,
                Properties = new byte[] { 0,2,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13492,
                Properties = new byte[] { 0,2,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13493,
                Properties = new byte[] { 1,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13494,
                Properties = new byte[] { 1,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13495,
                Properties = new byte[] { 1,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13496,
                Properties = new byte[] { 1,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13497,
                Properties = new byte[] { 1,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13498,
                Properties = new byte[] { 1,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13499,
                Properties = new byte[] { 1,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13500,
                Properties = new byte[] { 1,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13501,
                Properties = new byte[] { 1,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13502,
                Properties = new byte[] { 1,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13503,
                Properties = new byte[] { 1,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13504,
                Properties = new byte[] { 1,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13505,
                Properties = new byte[] { 1,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13506,
                Properties = new byte[] { 1,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13507,
                Properties = new byte[] { 1,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13508,
                Properties = new byte[] { 1,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13509,
                Properties = new byte[] { 1,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13510,
                Properties = new byte[] { 1,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13511,
                Properties = new byte[] { 1,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13512,
                Properties = new byte[] { 1,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13513,
                Properties = new byte[] { 1,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13514,
                Properties = new byte[] { 1,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13515,
                Properties = new byte[] { 1,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13516,
                Properties = new byte[] { 1,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13517,
                Properties = new byte[] { 1,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13518,
                Properties = new byte[] { 1,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13519,
                Properties = new byte[] { 1,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13520,
                Properties = new byte[] { 1,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13521,
                Properties = new byte[] { 1,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13522,
                Properties = new byte[] { 1,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13523,
                Properties = new byte[] { 1,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13524,
                Properties = new byte[] { 1,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13525,
                Properties = new byte[] { 1,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13526,
                Properties = new byte[] { 1,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13527,
                Properties = new byte[] { 1,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13528,
                Properties = new byte[] { 1,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13529,
                Properties = new byte[] { 1,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13530,
                Properties = new byte[] { 1,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13531,
                Properties = new byte[] { 1,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13532,
                Properties = new byte[] { 1,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13533,
                Properties = new byte[] { 1,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13534,
                Properties = new byte[] { 1,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13535,
                Properties = new byte[] { 1,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13536,
                Properties = new byte[] { 1,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13537,
                Properties = new byte[] { 1,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13538,
                Properties = new byte[] { 1,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13539,
                Properties = new byte[] { 1,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13540,
                Properties = new byte[] { 1,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13541,
                Properties = new byte[] { 1,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13542,
                Properties = new byte[] { 1,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13543,
                Properties = new byte[] { 1,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13544,
                Properties = new byte[] { 1,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13545,
                Properties = new byte[] { 1,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13546,
                Properties = new byte[] { 1,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13547,
                Properties = new byte[] { 1,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13548,
                Properties = new byte[] { 1,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13549,
                Properties = new byte[] { 1,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13550,
                Properties = new byte[] { 1,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13551,
                Properties = new byte[] { 1,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13552,
                Properties = new byte[] { 1,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13553,
                Properties = new byte[] { 1,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13554,
                Properties = new byte[] { 1,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13555,
                Properties = new byte[] { 1,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13556,
                Properties = new byte[] { 1,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13557,
                Properties = new byte[] { 1,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13558,
                Properties = new byte[] { 1,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13559,
                Properties = new byte[] { 1,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13560,
                Properties = new byte[] { 1,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13561,
                Properties = new byte[] { 1,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13562,
                Properties = new byte[] { 1,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13563,
                Properties = new byte[] { 1,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13564,
                Properties = new byte[] { 1,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13565,
                Properties = new byte[] { 1,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13566,
                Properties = new byte[] { 1,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13567,
                Properties = new byte[] { 1,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13568,
                Properties = new byte[] { 1,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13569,
                Properties = new byte[] { 1,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13570,
                Properties = new byte[] { 1,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13571,
                Properties = new byte[] { 1,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13572,
                Properties = new byte[] { 1,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13573,
                Properties = new byte[] { 1,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13574,
                Properties = new byte[] { 1,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13575,
                Properties = new byte[] { 1,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13576,
                Properties = new byte[] { 1,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13577,
                Properties = new byte[] { 1,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13578,
                Properties = new byte[] { 1,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13579,
                Properties = new byte[] { 1,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13580,
                Properties = new byte[] { 1,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13581,
                Properties = new byte[] { 1,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13582,
                Properties = new byte[] { 1,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13583,
                Properties = new byte[] { 1,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13584,
                Properties = new byte[] { 1,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13585,
                Properties = new byte[] { 1,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13586,
                Properties = new byte[] { 1,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13587,
                Properties = new byte[] { 1,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13588,
                Properties = new byte[] { 1,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13589,
                Properties = new byte[] { 1,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13590,
                Properties = new byte[] { 1,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13591,
                Properties = new byte[] { 1,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13592,
                Properties = new byte[] { 1,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13593,
                Properties = new byte[] { 1,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13594,
                Properties = new byte[] { 1,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13595,
                Properties = new byte[] { 1,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13596,
                Properties = new byte[] { 1,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13597,
                Properties = new byte[] { 1,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13598,
                Properties = new byte[] { 1,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13599,
                Properties = new byte[] { 1,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13600,
                Properties = new byte[] { 1,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13601,
                Properties = new byte[] { 2,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13602,
                Properties = new byte[] { 2,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13603,
                Properties = new byte[] { 2,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13604,
                Properties = new byte[] { 2,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13605,
                Properties = new byte[] { 2,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13606,
                Properties = new byte[] { 2,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13607,
                Properties = new byte[] { 2,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13608,
                Properties = new byte[] { 2,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13609,
                Properties = new byte[] { 2,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13610,
                Properties = new byte[] { 2,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13611,
                Properties = new byte[] { 2,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13612,
                Properties = new byte[] { 2,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13613,
                Properties = new byte[] { 2,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13614,
                Properties = new byte[] { 2,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13615,
                Properties = new byte[] { 2,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13616,
                Properties = new byte[] { 2,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13617,
                Properties = new byte[] { 2,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13618,
                Properties = new byte[] { 2,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13619,
                Properties = new byte[] { 2,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13620,
                Properties = new byte[] { 2,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13621,
                Properties = new byte[] { 2,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13622,
                Properties = new byte[] { 2,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13623,
                Properties = new byte[] { 2,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13624,
                Properties = new byte[] { 2,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13625,
                Properties = new byte[] { 2,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13626,
                Properties = new byte[] { 2,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13627,
                Properties = new byte[] { 2,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13628,
                Properties = new byte[] { 2,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13629,
                Properties = new byte[] { 2,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13630,
                Properties = new byte[] { 2,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13631,
                Properties = new byte[] { 2,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13632,
                Properties = new byte[] { 2,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13633,
                Properties = new byte[] { 2,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13634,
                Properties = new byte[] { 2,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13635,
                Properties = new byte[] { 2,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13636,
                Properties = new byte[] { 2,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13637,
                Properties = new byte[] { 2,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13638,
                Properties = new byte[] { 2,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13639,
                Properties = new byte[] { 2,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13640,
                Properties = new byte[] { 2,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13641,
                Properties = new byte[] { 2,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13642,
                Properties = new byte[] { 2,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13643,
                Properties = new byte[] { 2,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13644,
                Properties = new byte[] { 2,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13645,
                Properties = new byte[] { 2,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13646,
                Properties = new byte[] { 2,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13647,
                Properties = new byte[] { 2,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13648,
                Properties = new byte[] { 2,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13649,
                Properties = new byte[] { 2,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13650,
                Properties = new byte[] { 2,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13651,
                Properties = new byte[] { 2,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13652,
                Properties = new byte[] { 2,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13653,
                Properties = new byte[] { 2,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13654,
                Properties = new byte[] { 2,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13655,
                Properties = new byte[] { 2,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13656,
                Properties = new byte[] { 2,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13657,
                Properties = new byte[] { 2,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13658,
                Properties = new byte[] { 2,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13659,
                Properties = new byte[] { 2,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13660,
                Properties = new byte[] { 2,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13661,
                Properties = new byte[] { 2,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13662,
                Properties = new byte[] { 2,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13663,
                Properties = new byte[] { 2,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13664,
                Properties = new byte[] { 2,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13665,
                Properties = new byte[] { 2,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13666,
                Properties = new byte[] { 2,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13667,
                Properties = new byte[] { 2,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13668,
                Properties = new byte[] { 2,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13669,
                Properties = new byte[] { 2,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13670,
                Properties = new byte[] { 2,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13671,
                Properties = new byte[] { 2,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13672,
                Properties = new byte[] { 2,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13673,
                Properties = new byte[] { 2,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13674,
                Properties = new byte[] { 2,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13675,
                Properties = new byte[] { 2,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13676,
                Properties = new byte[] { 2,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13677,
                Properties = new byte[] { 2,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13678,
                Properties = new byte[] { 2,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13679,
                Properties = new byte[] { 2,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13680,
                Properties = new byte[] { 2,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13681,
                Properties = new byte[] { 2,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13682,
                Properties = new byte[] { 2,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13683,
                Properties = new byte[] { 2,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13684,
                Properties = new byte[] { 2,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13685,
                Properties = new byte[] { 2,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13686,
                Properties = new byte[] { 2,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13687,
                Properties = new byte[] { 2,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13688,
                Properties = new byte[] { 2,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13689,
                Properties = new byte[] { 2,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13690,
                Properties = new byte[] { 2,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13691,
                Properties = new byte[] { 2,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13692,
                Properties = new byte[] { 2,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13693,
                Properties = new byte[] { 2,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13694,
                Properties = new byte[] { 2,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13695,
                Properties = new byte[] { 2,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13696,
                Properties = new byte[] { 2,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13697,
                Properties = new byte[] { 2,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13698,
                Properties = new byte[] { 2,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13699,
                Properties = new byte[] { 2,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13700,
                Properties = new byte[] { 2,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13701,
                Properties = new byte[] { 2,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13702,
                Properties = new byte[] { 2,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13703,
                Properties = new byte[] { 2,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13704,
                Properties = new byte[] { 2,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13705,
                Properties = new byte[] { 2,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13706,
                Properties = new byte[] { 2,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13707,
                Properties = new byte[] { 2,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13708,
                Properties = new byte[] { 2,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
