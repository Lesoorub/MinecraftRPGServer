using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.nether_brick_wall)]
    public class nether_brick_wall : IBlockData
    {
        public short DefaultStateID => 13064;
        public float Hardness => 2f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 38;
        public short DroppedItem => 333;
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
                Id = 13061,
                Properties = new byte[] { 0,0,0,0,0,0 },
                CollisionShape = 391,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13062,
                Properties = new byte[] { 0,0,0,0,0,1 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13063,
                Properties = new byte[] { 0,0,0,0,0,2 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13064,
                Properties = new byte[] { 0,0,0,0,1,0 },
                CollisionShape = 391,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13065,
                Properties = new byte[] { 0,0,0,0,1,1 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13066,
                Properties = new byte[] { 0,0,0,0,1,2 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13067,
                Properties = new byte[] { 0,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13068,
                Properties = new byte[] { 0,0,0,1,0,1 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13069,
                Properties = new byte[] { 0,0,0,1,0,2 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13070,
                Properties = new byte[] { 0,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13071,
                Properties = new byte[] { 0,0,0,1,1,1 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13072,
                Properties = new byte[] { 0,0,0,1,1,2 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13073,
                Properties = new byte[] { 0,0,1,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13074,
                Properties = new byte[] { 0,0,1,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13075,
                Properties = new byte[] { 0,0,1,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13076,
                Properties = new byte[] { 0,0,1,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13077,
                Properties = new byte[] { 0,0,1,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13078,
                Properties = new byte[] { 0,0,1,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13079,
                Properties = new byte[] { 0,0,1,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13080,
                Properties = new byte[] { 0,0,1,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13081,
                Properties = new byte[] { 0,0,1,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13082,
                Properties = new byte[] { 0,0,1,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13083,
                Properties = new byte[] { 0,0,1,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13084,
                Properties = new byte[] { 0,0,1,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13085,
                Properties = new byte[] { 0,0,2,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13086,
                Properties = new byte[] { 0,0,2,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13087,
                Properties = new byte[] { 0,0,2,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13088,
                Properties = new byte[] { 0,0,2,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13089,
                Properties = new byte[] { 0,0,2,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13090,
                Properties = new byte[] { 0,0,2,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13091,
                Properties = new byte[] { 0,0,2,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13092,
                Properties = new byte[] { 0,0,2,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13093,
                Properties = new byte[] { 0,0,2,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13094,
                Properties = new byte[] { 0,0,2,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13095,
                Properties = new byte[] { 0,0,2,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13096,
                Properties = new byte[] { 0,0,2,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13097,
                Properties = new byte[] { 0,1,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13098,
                Properties = new byte[] { 0,1,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13099,
                Properties = new byte[] { 0,1,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13100,
                Properties = new byte[] { 0,1,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13101,
                Properties = new byte[] { 0,1,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13102,
                Properties = new byte[] { 0,1,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13103,
                Properties = new byte[] { 0,1,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13104,
                Properties = new byte[] { 0,1,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13105,
                Properties = new byte[] { 0,1,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13106,
                Properties = new byte[] { 0,1,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13107,
                Properties = new byte[] { 0,1,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13108,
                Properties = new byte[] { 0,1,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13109,
                Properties = new byte[] { 0,1,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13110,
                Properties = new byte[] { 0,1,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13111,
                Properties = new byte[] { 0,1,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13112,
                Properties = new byte[] { 0,1,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13113,
                Properties = new byte[] { 0,1,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13114,
                Properties = new byte[] { 0,1,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13115,
                Properties = new byte[] { 0,1,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13116,
                Properties = new byte[] { 0,1,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13117,
                Properties = new byte[] { 0,1,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13118,
                Properties = new byte[] { 0,1,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13119,
                Properties = new byte[] { 0,1,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13120,
                Properties = new byte[] { 0,1,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13121,
                Properties = new byte[] { 0,1,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13122,
                Properties = new byte[] { 0,1,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13123,
                Properties = new byte[] { 0,1,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13124,
                Properties = new byte[] { 0,1,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13125,
                Properties = new byte[] { 0,1,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13126,
                Properties = new byte[] { 0,1,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13127,
                Properties = new byte[] { 0,1,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13128,
                Properties = new byte[] { 0,1,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13129,
                Properties = new byte[] { 0,1,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13130,
                Properties = new byte[] { 0,1,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13131,
                Properties = new byte[] { 0,1,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13132,
                Properties = new byte[] { 0,1,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13133,
                Properties = new byte[] { 0,2,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13134,
                Properties = new byte[] { 0,2,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13135,
                Properties = new byte[] { 0,2,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13136,
                Properties = new byte[] { 0,2,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13137,
                Properties = new byte[] { 0,2,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13138,
                Properties = new byte[] { 0,2,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13139,
                Properties = new byte[] { 0,2,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13140,
                Properties = new byte[] { 0,2,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13141,
                Properties = new byte[] { 0,2,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13142,
                Properties = new byte[] { 0,2,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13143,
                Properties = new byte[] { 0,2,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13144,
                Properties = new byte[] { 0,2,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13145,
                Properties = new byte[] { 0,2,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13146,
                Properties = new byte[] { 0,2,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13147,
                Properties = new byte[] { 0,2,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13148,
                Properties = new byte[] { 0,2,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13149,
                Properties = new byte[] { 0,2,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13150,
                Properties = new byte[] { 0,2,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13151,
                Properties = new byte[] { 0,2,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13152,
                Properties = new byte[] { 0,2,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13153,
                Properties = new byte[] { 0,2,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13154,
                Properties = new byte[] { 0,2,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13155,
                Properties = new byte[] { 0,2,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13156,
                Properties = new byte[] { 0,2,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13157,
                Properties = new byte[] { 0,2,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13158,
                Properties = new byte[] { 0,2,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13159,
                Properties = new byte[] { 0,2,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13160,
                Properties = new byte[] { 0,2,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13161,
                Properties = new byte[] { 0,2,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13162,
                Properties = new byte[] { 0,2,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13163,
                Properties = new byte[] { 0,2,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13164,
                Properties = new byte[] { 0,2,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13165,
                Properties = new byte[] { 0,2,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13166,
                Properties = new byte[] { 0,2,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13167,
                Properties = new byte[] { 0,2,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13168,
                Properties = new byte[] { 0,2,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13169,
                Properties = new byte[] { 1,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13170,
                Properties = new byte[] { 1,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13171,
                Properties = new byte[] { 1,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13172,
                Properties = new byte[] { 1,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13173,
                Properties = new byte[] { 1,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13174,
                Properties = new byte[] { 1,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13175,
                Properties = new byte[] { 1,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13176,
                Properties = new byte[] { 1,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13177,
                Properties = new byte[] { 1,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13178,
                Properties = new byte[] { 1,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13179,
                Properties = new byte[] { 1,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13180,
                Properties = new byte[] { 1,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13181,
                Properties = new byte[] { 1,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13182,
                Properties = new byte[] { 1,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13183,
                Properties = new byte[] { 1,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13184,
                Properties = new byte[] { 1,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13185,
                Properties = new byte[] { 1,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13186,
                Properties = new byte[] { 1,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13187,
                Properties = new byte[] { 1,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13188,
                Properties = new byte[] { 1,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13189,
                Properties = new byte[] { 1,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13190,
                Properties = new byte[] { 1,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13191,
                Properties = new byte[] { 1,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13192,
                Properties = new byte[] { 1,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13193,
                Properties = new byte[] { 1,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13194,
                Properties = new byte[] { 1,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13195,
                Properties = new byte[] { 1,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13196,
                Properties = new byte[] { 1,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13197,
                Properties = new byte[] { 1,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13198,
                Properties = new byte[] { 1,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13199,
                Properties = new byte[] { 1,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13200,
                Properties = new byte[] { 1,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13201,
                Properties = new byte[] { 1,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13202,
                Properties = new byte[] { 1,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13203,
                Properties = new byte[] { 1,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13204,
                Properties = new byte[] { 1,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13205,
                Properties = new byte[] { 1,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13206,
                Properties = new byte[] { 1,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13207,
                Properties = new byte[] { 1,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13208,
                Properties = new byte[] { 1,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13209,
                Properties = new byte[] { 1,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13210,
                Properties = new byte[] { 1,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13211,
                Properties = new byte[] { 1,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13212,
                Properties = new byte[] { 1,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13213,
                Properties = new byte[] { 1,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13214,
                Properties = new byte[] { 1,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13215,
                Properties = new byte[] { 1,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13216,
                Properties = new byte[] { 1,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13217,
                Properties = new byte[] { 1,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13218,
                Properties = new byte[] { 1,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13219,
                Properties = new byte[] { 1,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13220,
                Properties = new byte[] { 1,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13221,
                Properties = new byte[] { 1,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13222,
                Properties = new byte[] { 1,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13223,
                Properties = new byte[] { 1,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13224,
                Properties = new byte[] { 1,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13225,
                Properties = new byte[] { 1,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13226,
                Properties = new byte[] { 1,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13227,
                Properties = new byte[] { 1,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13228,
                Properties = new byte[] { 1,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13229,
                Properties = new byte[] { 1,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13230,
                Properties = new byte[] { 1,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13231,
                Properties = new byte[] { 1,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13232,
                Properties = new byte[] { 1,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13233,
                Properties = new byte[] { 1,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13234,
                Properties = new byte[] { 1,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13235,
                Properties = new byte[] { 1,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13236,
                Properties = new byte[] { 1,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13237,
                Properties = new byte[] { 1,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13238,
                Properties = new byte[] { 1,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13239,
                Properties = new byte[] { 1,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13240,
                Properties = new byte[] { 1,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13241,
                Properties = new byte[] { 1,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13242,
                Properties = new byte[] { 1,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13243,
                Properties = new byte[] { 1,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13244,
                Properties = new byte[] { 1,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13245,
                Properties = new byte[] { 1,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13246,
                Properties = new byte[] { 1,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13247,
                Properties = new byte[] { 1,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13248,
                Properties = new byte[] { 1,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13249,
                Properties = new byte[] { 1,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13250,
                Properties = new byte[] { 1,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13251,
                Properties = new byte[] { 1,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13252,
                Properties = new byte[] { 1,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13253,
                Properties = new byte[] { 1,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13254,
                Properties = new byte[] { 1,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13255,
                Properties = new byte[] { 1,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13256,
                Properties = new byte[] { 1,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13257,
                Properties = new byte[] { 1,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13258,
                Properties = new byte[] { 1,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13259,
                Properties = new byte[] { 1,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13260,
                Properties = new byte[] { 1,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13261,
                Properties = new byte[] { 1,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13262,
                Properties = new byte[] { 1,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13263,
                Properties = new byte[] { 1,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13264,
                Properties = new byte[] { 1,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13265,
                Properties = new byte[] { 1,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13266,
                Properties = new byte[] { 1,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13267,
                Properties = new byte[] { 1,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13268,
                Properties = new byte[] { 1,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13269,
                Properties = new byte[] { 1,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13270,
                Properties = new byte[] { 1,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13271,
                Properties = new byte[] { 1,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13272,
                Properties = new byte[] { 1,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13273,
                Properties = new byte[] { 1,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13274,
                Properties = new byte[] { 1,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13275,
                Properties = new byte[] { 1,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13276,
                Properties = new byte[] { 1,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13277,
                Properties = new byte[] { 2,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13278,
                Properties = new byte[] { 2,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13279,
                Properties = new byte[] { 2,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13280,
                Properties = new byte[] { 2,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13281,
                Properties = new byte[] { 2,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13282,
                Properties = new byte[] { 2,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13283,
                Properties = new byte[] { 2,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13284,
                Properties = new byte[] { 2,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13285,
                Properties = new byte[] { 2,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13286,
                Properties = new byte[] { 2,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13287,
                Properties = new byte[] { 2,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13288,
                Properties = new byte[] { 2,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13289,
                Properties = new byte[] { 2,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13290,
                Properties = new byte[] { 2,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13291,
                Properties = new byte[] { 2,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13292,
                Properties = new byte[] { 2,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13293,
                Properties = new byte[] { 2,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13294,
                Properties = new byte[] { 2,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13295,
                Properties = new byte[] { 2,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13296,
                Properties = new byte[] { 2,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13297,
                Properties = new byte[] { 2,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13298,
                Properties = new byte[] { 2,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13299,
                Properties = new byte[] { 2,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13300,
                Properties = new byte[] { 2,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13301,
                Properties = new byte[] { 2,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13302,
                Properties = new byte[] { 2,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13303,
                Properties = new byte[] { 2,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13304,
                Properties = new byte[] { 2,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13305,
                Properties = new byte[] { 2,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13306,
                Properties = new byte[] { 2,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13307,
                Properties = new byte[] { 2,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13308,
                Properties = new byte[] { 2,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13309,
                Properties = new byte[] { 2,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13310,
                Properties = new byte[] { 2,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13311,
                Properties = new byte[] { 2,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13312,
                Properties = new byte[] { 2,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13313,
                Properties = new byte[] { 2,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13314,
                Properties = new byte[] { 2,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13315,
                Properties = new byte[] { 2,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13316,
                Properties = new byte[] { 2,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13317,
                Properties = new byte[] { 2,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13318,
                Properties = new byte[] { 2,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13319,
                Properties = new byte[] { 2,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13320,
                Properties = new byte[] { 2,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13321,
                Properties = new byte[] { 2,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13322,
                Properties = new byte[] { 2,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13323,
                Properties = new byte[] { 2,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13324,
                Properties = new byte[] { 2,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13325,
                Properties = new byte[] { 2,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13326,
                Properties = new byte[] { 2,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13327,
                Properties = new byte[] { 2,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13328,
                Properties = new byte[] { 2,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13329,
                Properties = new byte[] { 2,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13330,
                Properties = new byte[] { 2,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13331,
                Properties = new byte[] { 2,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13332,
                Properties = new byte[] { 2,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13333,
                Properties = new byte[] { 2,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13334,
                Properties = new byte[] { 2,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13335,
                Properties = new byte[] { 2,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13336,
                Properties = new byte[] { 2,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13337,
                Properties = new byte[] { 2,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13338,
                Properties = new byte[] { 2,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13339,
                Properties = new byte[] { 2,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13340,
                Properties = new byte[] { 2,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13341,
                Properties = new byte[] { 2,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13342,
                Properties = new byte[] { 2,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13343,
                Properties = new byte[] { 2,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13344,
                Properties = new byte[] { 2,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13345,
                Properties = new byte[] { 2,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13346,
                Properties = new byte[] { 2,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13347,
                Properties = new byte[] { 2,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13348,
                Properties = new byte[] { 2,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13349,
                Properties = new byte[] { 2,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13350,
                Properties = new byte[] { 2,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13351,
                Properties = new byte[] { 2,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13352,
                Properties = new byte[] { 2,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13353,
                Properties = new byte[] { 2,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13354,
                Properties = new byte[] { 2,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13355,
                Properties = new byte[] { 2,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13356,
                Properties = new byte[] { 2,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13357,
                Properties = new byte[] { 2,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13358,
                Properties = new byte[] { 2,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13359,
                Properties = new byte[] { 2,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13360,
                Properties = new byte[] { 2,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13361,
                Properties = new byte[] { 2,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13362,
                Properties = new byte[] { 2,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13363,
                Properties = new byte[] { 2,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13364,
                Properties = new byte[] { 2,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13365,
                Properties = new byte[] { 2,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13366,
                Properties = new byte[] { 2,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13367,
                Properties = new byte[] { 2,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13368,
                Properties = new byte[] { 2,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13369,
                Properties = new byte[] { 2,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13370,
                Properties = new byte[] { 2,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13371,
                Properties = new byte[] { 2,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13372,
                Properties = new byte[] { 2,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13373,
                Properties = new byte[] { 2,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13374,
                Properties = new byte[] { 2,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13375,
                Properties = new byte[] { 2,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13376,
                Properties = new byte[] { 2,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13377,
                Properties = new byte[] { 2,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13378,
                Properties = new byte[] { 2,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13379,
                Properties = new byte[] { 2,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13380,
                Properties = new byte[] { 2,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13381,
                Properties = new byte[] { 2,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13382,
                Properties = new byte[] { 2,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13383,
                Properties = new byte[] { 2,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13384,
                Properties = new byte[] { 2,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
