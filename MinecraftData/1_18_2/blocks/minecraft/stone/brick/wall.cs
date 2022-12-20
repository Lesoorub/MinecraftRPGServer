using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.stone_brick_wall)]
    public class stone_brick_wall : IBlockData
    {
        public short DefaultStateID => 12740;
        public state DefaultState => States[3];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 332;
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
                Id = 12737,
                Properties = new byte[] { 0,0,0,0,0,0 },
                CollisionShape = 391,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12738,
                Properties = new byte[] { 0,0,0,0,0,1 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12739,
                Properties = new byte[] { 0,0,0,0,0,2 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12740,
                Properties = new byte[] { 0,0,0,0,1,0 },
                CollisionShape = 391,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12741,
                Properties = new byte[] { 0,0,0,0,1,1 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12742,
                Properties = new byte[] { 0,0,0,0,1,2 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12743,
                Properties = new byte[] { 0,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12744,
                Properties = new byte[] { 0,0,0,1,0,1 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12745,
                Properties = new byte[] { 0,0,0,1,0,2 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12746,
                Properties = new byte[] { 0,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12747,
                Properties = new byte[] { 0,0,0,1,1,1 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12748,
                Properties = new byte[] { 0,0,0,1,1,2 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12749,
                Properties = new byte[] { 0,0,1,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12750,
                Properties = new byte[] { 0,0,1,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12751,
                Properties = new byte[] { 0,0,1,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12752,
                Properties = new byte[] { 0,0,1,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12753,
                Properties = new byte[] { 0,0,1,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12754,
                Properties = new byte[] { 0,0,1,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12755,
                Properties = new byte[] { 0,0,1,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12756,
                Properties = new byte[] { 0,0,1,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12757,
                Properties = new byte[] { 0,0,1,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12758,
                Properties = new byte[] { 0,0,1,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12759,
                Properties = new byte[] { 0,0,1,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12760,
                Properties = new byte[] { 0,0,1,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12761,
                Properties = new byte[] { 0,0,2,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12762,
                Properties = new byte[] { 0,0,2,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12763,
                Properties = new byte[] { 0,0,2,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12764,
                Properties = new byte[] { 0,0,2,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12765,
                Properties = new byte[] { 0,0,2,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12766,
                Properties = new byte[] { 0,0,2,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12767,
                Properties = new byte[] { 0,0,2,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12768,
                Properties = new byte[] { 0,0,2,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12769,
                Properties = new byte[] { 0,0,2,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12770,
                Properties = new byte[] { 0,0,2,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12771,
                Properties = new byte[] { 0,0,2,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12772,
                Properties = new byte[] { 0,0,2,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12773,
                Properties = new byte[] { 0,1,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12774,
                Properties = new byte[] { 0,1,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12775,
                Properties = new byte[] { 0,1,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12776,
                Properties = new byte[] { 0,1,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12777,
                Properties = new byte[] { 0,1,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12778,
                Properties = new byte[] { 0,1,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12779,
                Properties = new byte[] { 0,1,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12780,
                Properties = new byte[] { 0,1,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12781,
                Properties = new byte[] { 0,1,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12782,
                Properties = new byte[] { 0,1,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12783,
                Properties = new byte[] { 0,1,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12784,
                Properties = new byte[] { 0,1,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12785,
                Properties = new byte[] { 0,1,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12786,
                Properties = new byte[] { 0,1,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12787,
                Properties = new byte[] { 0,1,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12788,
                Properties = new byte[] { 0,1,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12789,
                Properties = new byte[] { 0,1,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12790,
                Properties = new byte[] { 0,1,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12791,
                Properties = new byte[] { 0,1,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12792,
                Properties = new byte[] { 0,1,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12793,
                Properties = new byte[] { 0,1,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12794,
                Properties = new byte[] { 0,1,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12795,
                Properties = new byte[] { 0,1,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12796,
                Properties = new byte[] { 0,1,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12797,
                Properties = new byte[] { 0,1,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12798,
                Properties = new byte[] { 0,1,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12799,
                Properties = new byte[] { 0,1,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12800,
                Properties = new byte[] { 0,1,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12801,
                Properties = new byte[] { 0,1,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12802,
                Properties = new byte[] { 0,1,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12803,
                Properties = new byte[] { 0,1,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12804,
                Properties = new byte[] { 0,1,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12805,
                Properties = new byte[] { 0,1,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12806,
                Properties = new byte[] { 0,1,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12807,
                Properties = new byte[] { 0,1,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12808,
                Properties = new byte[] { 0,1,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12809,
                Properties = new byte[] { 0,2,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12810,
                Properties = new byte[] { 0,2,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12811,
                Properties = new byte[] { 0,2,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12812,
                Properties = new byte[] { 0,2,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12813,
                Properties = new byte[] { 0,2,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12814,
                Properties = new byte[] { 0,2,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12815,
                Properties = new byte[] { 0,2,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12816,
                Properties = new byte[] { 0,2,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12817,
                Properties = new byte[] { 0,2,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12818,
                Properties = new byte[] { 0,2,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12819,
                Properties = new byte[] { 0,2,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12820,
                Properties = new byte[] { 0,2,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12821,
                Properties = new byte[] { 0,2,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12822,
                Properties = new byte[] { 0,2,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12823,
                Properties = new byte[] { 0,2,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12824,
                Properties = new byte[] { 0,2,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12825,
                Properties = new byte[] { 0,2,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12826,
                Properties = new byte[] { 0,2,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12827,
                Properties = new byte[] { 0,2,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12828,
                Properties = new byte[] { 0,2,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12829,
                Properties = new byte[] { 0,2,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12830,
                Properties = new byte[] { 0,2,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12831,
                Properties = new byte[] { 0,2,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12832,
                Properties = new byte[] { 0,2,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12833,
                Properties = new byte[] { 0,2,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12834,
                Properties = new byte[] { 0,2,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12835,
                Properties = new byte[] { 0,2,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12836,
                Properties = new byte[] { 0,2,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12837,
                Properties = new byte[] { 0,2,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12838,
                Properties = new byte[] { 0,2,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12839,
                Properties = new byte[] { 0,2,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12840,
                Properties = new byte[] { 0,2,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12841,
                Properties = new byte[] { 0,2,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12842,
                Properties = new byte[] { 0,2,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12843,
                Properties = new byte[] { 0,2,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12844,
                Properties = new byte[] { 0,2,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12845,
                Properties = new byte[] { 1,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12846,
                Properties = new byte[] { 1,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12847,
                Properties = new byte[] { 1,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12848,
                Properties = new byte[] { 1,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12849,
                Properties = new byte[] { 1,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12850,
                Properties = new byte[] { 1,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12851,
                Properties = new byte[] { 1,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12852,
                Properties = new byte[] { 1,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12853,
                Properties = new byte[] { 1,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12854,
                Properties = new byte[] { 1,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12855,
                Properties = new byte[] { 1,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12856,
                Properties = new byte[] { 1,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12857,
                Properties = new byte[] { 1,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12858,
                Properties = new byte[] { 1,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12859,
                Properties = new byte[] { 1,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12860,
                Properties = new byte[] { 1,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12861,
                Properties = new byte[] { 1,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12862,
                Properties = new byte[] { 1,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12863,
                Properties = new byte[] { 1,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12864,
                Properties = new byte[] { 1,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12865,
                Properties = new byte[] { 1,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12866,
                Properties = new byte[] { 1,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12867,
                Properties = new byte[] { 1,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12868,
                Properties = new byte[] { 1,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12869,
                Properties = new byte[] { 1,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12870,
                Properties = new byte[] { 1,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12871,
                Properties = new byte[] { 1,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12872,
                Properties = new byte[] { 1,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12873,
                Properties = new byte[] { 1,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12874,
                Properties = new byte[] { 1,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12875,
                Properties = new byte[] { 1,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12876,
                Properties = new byte[] { 1,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12877,
                Properties = new byte[] { 1,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12878,
                Properties = new byte[] { 1,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12879,
                Properties = new byte[] { 1,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12880,
                Properties = new byte[] { 1,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12881,
                Properties = new byte[] { 1,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12882,
                Properties = new byte[] { 1,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12883,
                Properties = new byte[] { 1,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12884,
                Properties = new byte[] { 1,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12885,
                Properties = new byte[] { 1,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12886,
                Properties = new byte[] { 1,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12887,
                Properties = new byte[] { 1,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12888,
                Properties = new byte[] { 1,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12889,
                Properties = new byte[] { 1,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12890,
                Properties = new byte[] { 1,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12891,
                Properties = new byte[] { 1,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12892,
                Properties = new byte[] { 1,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12893,
                Properties = new byte[] { 1,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12894,
                Properties = new byte[] { 1,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12895,
                Properties = new byte[] { 1,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12896,
                Properties = new byte[] { 1,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12897,
                Properties = new byte[] { 1,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12898,
                Properties = new byte[] { 1,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12899,
                Properties = new byte[] { 1,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12900,
                Properties = new byte[] { 1,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12901,
                Properties = new byte[] { 1,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12902,
                Properties = new byte[] { 1,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12903,
                Properties = new byte[] { 1,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12904,
                Properties = new byte[] { 1,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12905,
                Properties = new byte[] { 1,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12906,
                Properties = new byte[] { 1,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12907,
                Properties = new byte[] { 1,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12908,
                Properties = new byte[] { 1,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12909,
                Properties = new byte[] { 1,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12910,
                Properties = new byte[] { 1,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12911,
                Properties = new byte[] { 1,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12912,
                Properties = new byte[] { 1,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12913,
                Properties = new byte[] { 1,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12914,
                Properties = new byte[] { 1,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12915,
                Properties = new byte[] { 1,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12916,
                Properties = new byte[] { 1,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12917,
                Properties = new byte[] { 1,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12918,
                Properties = new byte[] { 1,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12919,
                Properties = new byte[] { 1,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12920,
                Properties = new byte[] { 1,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12921,
                Properties = new byte[] { 1,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12922,
                Properties = new byte[] { 1,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12923,
                Properties = new byte[] { 1,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12924,
                Properties = new byte[] { 1,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12925,
                Properties = new byte[] { 1,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12926,
                Properties = new byte[] { 1,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12927,
                Properties = new byte[] { 1,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12928,
                Properties = new byte[] { 1,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12929,
                Properties = new byte[] { 1,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12930,
                Properties = new byte[] { 1,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12931,
                Properties = new byte[] { 1,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12932,
                Properties = new byte[] { 1,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12933,
                Properties = new byte[] { 1,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12934,
                Properties = new byte[] { 1,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12935,
                Properties = new byte[] { 1,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12936,
                Properties = new byte[] { 1,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12937,
                Properties = new byte[] { 1,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12938,
                Properties = new byte[] { 1,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12939,
                Properties = new byte[] { 1,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12940,
                Properties = new byte[] { 1,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12941,
                Properties = new byte[] { 1,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12942,
                Properties = new byte[] { 1,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12943,
                Properties = new byte[] { 1,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12944,
                Properties = new byte[] { 1,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12945,
                Properties = new byte[] { 1,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12946,
                Properties = new byte[] { 1,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12947,
                Properties = new byte[] { 1,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12948,
                Properties = new byte[] { 1,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12949,
                Properties = new byte[] { 1,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12950,
                Properties = new byte[] { 1,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12951,
                Properties = new byte[] { 1,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12952,
                Properties = new byte[] { 1,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12953,
                Properties = new byte[] { 2,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12954,
                Properties = new byte[] { 2,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12955,
                Properties = new byte[] { 2,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12956,
                Properties = new byte[] { 2,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12957,
                Properties = new byte[] { 2,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12958,
                Properties = new byte[] { 2,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12959,
                Properties = new byte[] { 2,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12960,
                Properties = new byte[] { 2,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12961,
                Properties = new byte[] { 2,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12962,
                Properties = new byte[] { 2,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12963,
                Properties = new byte[] { 2,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12964,
                Properties = new byte[] { 2,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12965,
                Properties = new byte[] { 2,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12966,
                Properties = new byte[] { 2,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12967,
                Properties = new byte[] { 2,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12968,
                Properties = new byte[] { 2,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12969,
                Properties = new byte[] { 2,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12970,
                Properties = new byte[] { 2,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12971,
                Properties = new byte[] { 2,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12972,
                Properties = new byte[] { 2,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12973,
                Properties = new byte[] { 2,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12974,
                Properties = new byte[] { 2,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12975,
                Properties = new byte[] { 2,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12976,
                Properties = new byte[] { 2,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12977,
                Properties = new byte[] { 2,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12978,
                Properties = new byte[] { 2,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12979,
                Properties = new byte[] { 2,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12980,
                Properties = new byte[] { 2,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12981,
                Properties = new byte[] { 2,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12982,
                Properties = new byte[] { 2,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12983,
                Properties = new byte[] { 2,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12984,
                Properties = new byte[] { 2,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12985,
                Properties = new byte[] { 2,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12986,
                Properties = new byte[] { 2,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12987,
                Properties = new byte[] { 2,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12988,
                Properties = new byte[] { 2,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12989,
                Properties = new byte[] { 2,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12990,
                Properties = new byte[] { 2,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12991,
                Properties = new byte[] { 2,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12992,
                Properties = new byte[] { 2,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12993,
                Properties = new byte[] { 2,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12994,
                Properties = new byte[] { 2,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12995,
                Properties = new byte[] { 2,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12996,
                Properties = new byte[] { 2,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12997,
                Properties = new byte[] { 2,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12998,
                Properties = new byte[] { 2,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 12999,
                Properties = new byte[] { 2,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13000,
                Properties = new byte[] { 2,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13001,
                Properties = new byte[] { 2,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13002,
                Properties = new byte[] { 2,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13003,
                Properties = new byte[] { 2,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13004,
                Properties = new byte[] { 2,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13005,
                Properties = new byte[] { 2,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13006,
                Properties = new byte[] { 2,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13007,
                Properties = new byte[] { 2,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13008,
                Properties = new byte[] { 2,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13009,
                Properties = new byte[] { 2,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13010,
                Properties = new byte[] { 2,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13011,
                Properties = new byte[] { 2,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13012,
                Properties = new byte[] { 2,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13013,
                Properties = new byte[] { 2,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13014,
                Properties = new byte[] { 2,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13015,
                Properties = new byte[] { 2,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13016,
                Properties = new byte[] { 2,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13017,
                Properties = new byte[] { 2,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13018,
                Properties = new byte[] { 2,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13019,
                Properties = new byte[] { 2,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13020,
                Properties = new byte[] { 2,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13021,
                Properties = new byte[] { 2,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13022,
                Properties = new byte[] { 2,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13023,
                Properties = new byte[] { 2,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13024,
                Properties = new byte[] { 2,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13025,
                Properties = new byte[] { 2,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13026,
                Properties = new byte[] { 2,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13027,
                Properties = new byte[] { 2,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13028,
                Properties = new byte[] { 2,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13029,
                Properties = new byte[] { 2,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13030,
                Properties = new byte[] { 2,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13031,
                Properties = new byte[] { 2,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13032,
                Properties = new byte[] { 2,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13033,
                Properties = new byte[] { 2,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13034,
                Properties = new byte[] { 2,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13035,
                Properties = new byte[] { 2,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13036,
                Properties = new byte[] { 2,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13037,
                Properties = new byte[] { 2,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13038,
                Properties = new byte[] { 2,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13039,
                Properties = new byte[] { 2,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13040,
                Properties = new byte[] { 2,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13041,
                Properties = new byte[] { 2,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13042,
                Properties = new byte[] { 2,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13043,
                Properties = new byte[] { 2,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13044,
                Properties = new byte[] { 2,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13045,
                Properties = new byte[] { 2,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13046,
                Properties = new byte[] { 2,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13047,
                Properties = new byte[] { 2,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13048,
                Properties = new byte[] { 2,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13049,
                Properties = new byte[] { 2,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13050,
                Properties = new byte[] { 2,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13051,
                Properties = new byte[] { 2,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13052,
                Properties = new byte[] { 2,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13053,
                Properties = new byte[] { 2,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13054,
                Properties = new byte[] { 2,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13055,
                Properties = new byte[] { 2,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13056,
                Properties = new byte[] { 2,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13057,
                Properties = new byte[] { 2,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13058,
                Properties = new byte[] { 2,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13059,
                Properties = new byte[] { 2,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13060,
                Properties = new byte[] { 2,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
