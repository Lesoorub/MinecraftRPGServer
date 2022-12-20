using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.glow_lichen)]
    public class glow_lichen : IBlockData
    {
        public short DefaultStateID => 5020;
        public state DefaultState => States[127];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 71;
        public short DroppedItem => 300;
        public MinecraftMaterial Material => MinecraftMaterial.replaceable_plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "down", new List<string>() { "True", "False" } },
            { "east", new List<string>() { "True", "False" } },
            { "north", new List<string>() { "True", "False" } },
            { "south", new List<string>() { "True", "False" } },
            { "up", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } },
            { "west", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4893,
                Properties = new byte[] { 0,0,0,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4894,
                Properties = new byte[] { 0,0,0,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4895,
                Properties = new byte[] { 0,0,0,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4896,
                Properties = new byte[] { 0,0,0,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4897,
                Properties = new byte[] { 0,0,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4898,
                Properties = new byte[] { 0,0,0,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4899,
                Properties = new byte[] { 0,0,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4900,
                Properties = new byte[] { 0,0,0,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4901,
                Properties = new byte[] { 0,0,0,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4902,
                Properties = new byte[] { 0,0,0,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4903,
                Properties = new byte[] { 0,0,0,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4904,
                Properties = new byte[] { 0,0,0,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4905,
                Properties = new byte[] { 0,0,0,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4906,
                Properties = new byte[] { 0,0,0,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4907,
                Properties = new byte[] { 0,0,0,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4908,
                Properties = new byte[] { 0,0,0,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4909,
                Properties = new byte[] { 0,0,1,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4910,
                Properties = new byte[] { 0,0,1,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4911,
                Properties = new byte[] { 0,0,1,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4912,
                Properties = new byte[] { 0,0,1,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4913,
                Properties = new byte[] { 0,0,1,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4914,
                Properties = new byte[] { 0,0,1,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4915,
                Properties = new byte[] { 0,0,1,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4916,
                Properties = new byte[] { 0,0,1,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4917,
                Properties = new byte[] { 0,0,1,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4918,
                Properties = new byte[] { 0,0,1,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4919,
                Properties = new byte[] { 0,0,1,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4920,
                Properties = new byte[] { 0,0,1,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4921,
                Properties = new byte[] { 0,0,1,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4922,
                Properties = new byte[] { 0,0,1,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4923,
                Properties = new byte[] { 0,0,1,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4924,
                Properties = new byte[] { 0,0,1,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4925,
                Properties = new byte[] { 0,1,0,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4926,
                Properties = new byte[] { 0,1,0,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4927,
                Properties = new byte[] { 0,1,0,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4928,
                Properties = new byte[] { 0,1,0,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4929,
                Properties = new byte[] { 0,1,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4930,
                Properties = new byte[] { 0,1,0,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4931,
                Properties = new byte[] { 0,1,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4932,
                Properties = new byte[] { 0,1,0,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4933,
                Properties = new byte[] { 0,1,0,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4934,
                Properties = new byte[] { 0,1,0,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4935,
                Properties = new byte[] { 0,1,0,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4936,
                Properties = new byte[] { 0,1,0,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4937,
                Properties = new byte[] { 0,1,0,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4938,
                Properties = new byte[] { 0,1,0,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4939,
                Properties = new byte[] { 0,1,0,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4940,
                Properties = new byte[] { 0,1,0,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4941,
                Properties = new byte[] { 0,1,1,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4942,
                Properties = new byte[] { 0,1,1,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4943,
                Properties = new byte[] { 0,1,1,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4944,
                Properties = new byte[] { 0,1,1,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4945,
                Properties = new byte[] { 0,1,1,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4946,
                Properties = new byte[] { 0,1,1,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4947,
                Properties = new byte[] { 0,1,1,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4948,
                Properties = new byte[] { 0,1,1,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4949,
                Properties = new byte[] { 0,1,1,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4950,
                Properties = new byte[] { 0,1,1,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4951,
                Properties = new byte[] { 0,1,1,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4952,
                Properties = new byte[] { 0,1,1,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4953,
                Properties = new byte[] { 0,1,1,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4954,
                Properties = new byte[] { 0,1,1,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4955,
                Properties = new byte[] { 0,1,1,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4956,
                Properties = new byte[] { 0,1,1,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4957,
                Properties = new byte[] { 1,0,0,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4958,
                Properties = new byte[] { 1,0,0,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4959,
                Properties = new byte[] { 1,0,0,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4960,
                Properties = new byte[] { 1,0,0,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4961,
                Properties = new byte[] { 1,0,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4962,
                Properties = new byte[] { 1,0,0,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4963,
                Properties = new byte[] { 1,0,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4964,
                Properties = new byte[] { 1,0,0,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4965,
                Properties = new byte[] { 1,0,0,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4966,
                Properties = new byte[] { 1,0,0,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4967,
                Properties = new byte[] { 1,0,0,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4968,
                Properties = new byte[] { 1,0,0,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4969,
                Properties = new byte[] { 1,0,0,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4970,
                Properties = new byte[] { 1,0,0,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4971,
                Properties = new byte[] { 1,0,0,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4972,
                Properties = new byte[] { 1,0,0,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4973,
                Properties = new byte[] { 1,0,1,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4974,
                Properties = new byte[] { 1,0,1,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4975,
                Properties = new byte[] { 1,0,1,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4976,
                Properties = new byte[] { 1,0,1,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4977,
                Properties = new byte[] { 1,0,1,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4978,
                Properties = new byte[] { 1,0,1,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4979,
                Properties = new byte[] { 1,0,1,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4980,
                Properties = new byte[] { 1,0,1,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4981,
                Properties = new byte[] { 1,0,1,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4982,
                Properties = new byte[] { 1,0,1,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4983,
                Properties = new byte[] { 1,0,1,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4984,
                Properties = new byte[] { 1,0,1,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4985,
                Properties = new byte[] { 1,0,1,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4986,
                Properties = new byte[] { 1,0,1,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4987,
                Properties = new byte[] { 1,0,1,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4988,
                Properties = new byte[] { 1,0,1,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4989,
                Properties = new byte[] { 1,1,0,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4990,
                Properties = new byte[] { 1,1,0,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4991,
                Properties = new byte[] { 1,1,0,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4992,
                Properties = new byte[] { 1,1,0,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4993,
                Properties = new byte[] { 1,1,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4994,
                Properties = new byte[] { 1,1,0,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4995,
                Properties = new byte[] { 1,1,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4996,
                Properties = new byte[] { 1,1,0,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4997,
                Properties = new byte[] { 1,1,0,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4998,
                Properties = new byte[] { 1,1,0,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4999,
                Properties = new byte[] { 1,1,0,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5000,
                Properties = new byte[] { 1,1,0,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5001,
                Properties = new byte[] { 1,1,0,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5002,
                Properties = new byte[] { 1,1,0,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5003,
                Properties = new byte[] { 1,1,0,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5004,
                Properties = new byte[] { 1,1,0,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5005,
                Properties = new byte[] { 1,1,1,0,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5006,
                Properties = new byte[] { 1,1,1,0,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5007,
                Properties = new byte[] { 1,1,1,0,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5008,
                Properties = new byte[] { 1,1,1,0,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5009,
                Properties = new byte[] { 1,1,1,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5010,
                Properties = new byte[] { 1,1,1,0,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5011,
                Properties = new byte[] { 1,1,1,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5012,
                Properties = new byte[] { 1,1,1,0,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5013,
                Properties = new byte[] { 1,1,1,1,0,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5014,
                Properties = new byte[] { 1,1,1,1,0,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5015,
                Properties = new byte[] { 1,1,1,1,0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5016,
                Properties = new byte[] { 1,1,1,1,0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5017,
                Properties = new byte[] { 1,1,1,1,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5018,
                Properties = new byte[] { 1,1,1,1,1,0,1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5019,
                Properties = new byte[] { 1,1,1,1,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5020,
                Properties = new byte[] { 1,1,1,1,1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
