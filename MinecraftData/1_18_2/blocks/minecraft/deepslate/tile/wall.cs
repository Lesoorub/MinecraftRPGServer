using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.deepslate_tile_wall)]
    public class deepslate_tile_wall : IBlockData
    {
        public short DefaultStateID => 19598;
        public float Hardness => 3.5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 74;
        public short DroppedItem => 345;
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
                Id = 19595,
                Properties = new byte[] { 0,0,0,0,0,0 },
                CollisionShape = 391,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19596,
                Properties = new byte[] { 0,0,0,0,0,1 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19597,
                Properties = new byte[] { 0,0,0,0,0,2 },
                CollisionShape = 392,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19598,
                Properties = new byte[] { 0,0,0,0,1,0 },
                CollisionShape = 391,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19599,
                Properties = new byte[] { 0,0,0,0,1,1 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19600,
                Properties = new byte[] { 0,0,0,0,1,2 },
                CollisionShape = 392,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19601,
                Properties = new byte[] { 0,0,0,1,0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19602,
                Properties = new byte[] { 0,0,0,1,0,1 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19603,
                Properties = new byte[] { 0,0,0,1,0,2 },
                CollisionShape = 397,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19604,
                Properties = new byte[] { 0,0,0,1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19605,
                Properties = new byte[] { 0,0,0,1,1,1 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19606,
                Properties = new byte[] { 0,0,0,1,1,2 },
                CollisionShape = 397,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19607,
                Properties = new byte[] { 0,0,1,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19608,
                Properties = new byte[] { 0,0,1,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19609,
                Properties = new byte[] { 0,0,1,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19610,
                Properties = new byte[] { 0,0,1,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19611,
                Properties = new byte[] { 0,0,1,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19612,
                Properties = new byte[] { 0,0,1,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19613,
                Properties = new byte[] { 0,0,1,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19614,
                Properties = new byte[] { 0,0,1,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19615,
                Properties = new byte[] { 0,0,1,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19616,
                Properties = new byte[] { 0,0,1,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19617,
                Properties = new byte[] { 0,0,1,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19618,
                Properties = new byte[] { 0,0,1,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19619,
                Properties = new byte[] { 0,0,2,0,0,0 },
                CollisionShape = 400,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19620,
                Properties = new byte[] { 0,0,2,0,0,1 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19621,
                Properties = new byte[] { 0,0,2,0,0,2 },
                CollisionShape = 404,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19622,
                Properties = new byte[] { 0,0,2,0,1,0 },
                CollisionShape = 400,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19623,
                Properties = new byte[] { 0,0,2,0,1,1 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19624,
                Properties = new byte[] { 0,0,2,0,1,2 },
                CollisionShape = 404,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19625,
                Properties = new byte[] { 0,0,2,1,0,0 },
                CollisionShape = 408,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19626,
                Properties = new byte[] { 0,0,2,1,0,1 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19627,
                Properties = new byte[] { 0,0,2,1,0,2 },
                CollisionShape = 411,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19628,
                Properties = new byte[] { 0,0,2,1,1,0 },
                CollisionShape = 408,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19629,
                Properties = new byte[] { 0,0,2,1,1,1 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19630,
                Properties = new byte[] { 0,0,2,1,1,2 },
                CollisionShape = 411,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19631,
                Properties = new byte[] { 0,1,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19632,
                Properties = new byte[] { 0,1,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19633,
                Properties = new byte[] { 0,1,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19634,
                Properties = new byte[] { 0,1,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19635,
                Properties = new byte[] { 0,1,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19636,
                Properties = new byte[] { 0,1,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19637,
                Properties = new byte[] { 0,1,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19638,
                Properties = new byte[] { 0,1,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19639,
                Properties = new byte[] { 0,1,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19640,
                Properties = new byte[] { 0,1,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19641,
                Properties = new byte[] { 0,1,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19642,
                Properties = new byte[] { 0,1,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19643,
                Properties = new byte[] { 0,1,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19644,
                Properties = new byte[] { 0,1,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19645,
                Properties = new byte[] { 0,1,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19646,
                Properties = new byte[] { 0,1,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19647,
                Properties = new byte[] { 0,1,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19648,
                Properties = new byte[] { 0,1,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19649,
                Properties = new byte[] { 0,1,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19650,
                Properties = new byte[] { 0,1,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19651,
                Properties = new byte[] { 0,1,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19652,
                Properties = new byte[] { 0,1,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19653,
                Properties = new byte[] { 0,1,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19654,
                Properties = new byte[] { 0,1,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19655,
                Properties = new byte[] { 0,1,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19656,
                Properties = new byte[] { 0,1,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19657,
                Properties = new byte[] { 0,1,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19658,
                Properties = new byte[] { 0,1,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19659,
                Properties = new byte[] { 0,1,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19660,
                Properties = new byte[] { 0,1,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19661,
                Properties = new byte[] { 0,1,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19662,
                Properties = new byte[] { 0,1,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19663,
                Properties = new byte[] { 0,1,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19664,
                Properties = new byte[] { 0,1,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19665,
                Properties = new byte[] { 0,1,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19666,
                Properties = new byte[] { 0,1,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19667,
                Properties = new byte[] { 0,2,0,0,0,0 },
                CollisionShape = 418,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19668,
                Properties = new byte[] { 0,2,0,0,0,1 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19669,
                Properties = new byte[] { 0,2,0,0,0,2 },
                CollisionShape = 421,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19670,
                Properties = new byte[] { 0,2,0,0,1,0 },
                CollisionShape = 418,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19671,
                Properties = new byte[] { 0,2,0,0,1,1 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19672,
                Properties = new byte[] { 0,2,0,0,1,2 },
                CollisionShape = 421,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19673,
                Properties = new byte[] { 0,2,0,1,0,0 },
                CollisionShape = 425,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19674,
                Properties = new byte[] { 0,2,0,1,0,1 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19675,
                Properties = new byte[] { 0,2,0,1,0,2 },
                CollisionShape = 428,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19676,
                Properties = new byte[] { 0,2,0,1,1,0 },
                CollisionShape = 425,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19677,
                Properties = new byte[] { 0,2,0,1,1,1 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19678,
                Properties = new byte[] { 0,2,0,1,1,2 },
                CollisionShape = 428,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19679,
                Properties = new byte[] { 0,2,1,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19680,
                Properties = new byte[] { 0,2,1,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19681,
                Properties = new byte[] { 0,2,1,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19682,
                Properties = new byte[] { 0,2,1,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19683,
                Properties = new byte[] { 0,2,1,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19684,
                Properties = new byte[] { 0,2,1,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19685,
                Properties = new byte[] { 0,2,1,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19686,
                Properties = new byte[] { 0,2,1,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19687,
                Properties = new byte[] { 0,2,1,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19688,
                Properties = new byte[] { 0,2,1,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19689,
                Properties = new byte[] { 0,2,1,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19690,
                Properties = new byte[] { 0,2,1,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19691,
                Properties = new byte[] { 0,2,2,0,0,0 },
                CollisionShape = 432,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19692,
                Properties = new byte[] { 0,2,2,0,0,1 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19693,
                Properties = new byte[] { 0,2,2,0,0,2 },
                CollisionShape = 435,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19694,
                Properties = new byte[] { 0,2,2,0,1,0 },
                CollisionShape = 432,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19695,
                Properties = new byte[] { 0,2,2,0,1,1 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19696,
                Properties = new byte[] { 0,2,2,0,1,2 },
                CollisionShape = 435,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19697,
                Properties = new byte[] { 0,2,2,1,0,0 },
                CollisionShape = 439,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19698,
                Properties = new byte[] { 0,2,2,1,0,1 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19699,
                Properties = new byte[] { 0,2,2,1,0,2 },
                CollisionShape = 440,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19700,
                Properties = new byte[] { 0,2,2,1,1,0 },
                CollisionShape = 439,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19701,
                Properties = new byte[] { 0,2,2,1,1,1 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19702,
                Properties = new byte[] { 0,2,2,1,1,2 },
                CollisionShape = 440,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19703,
                Properties = new byte[] { 1,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19704,
                Properties = new byte[] { 1,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19705,
                Properties = new byte[] { 1,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19706,
                Properties = new byte[] { 1,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19707,
                Properties = new byte[] { 1,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19708,
                Properties = new byte[] { 1,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19709,
                Properties = new byte[] { 1,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19710,
                Properties = new byte[] { 1,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19711,
                Properties = new byte[] { 1,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19712,
                Properties = new byte[] { 1,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19713,
                Properties = new byte[] { 1,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19714,
                Properties = new byte[] { 1,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19715,
                Properties = new byte[] { 1,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19716,
                Properties = new byte[] { 1,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19717,
                Properties = new byte[] { 1,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19718,
                Properties = new byte[] { 1,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19719,
                Properties = new byte[] { 1,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19720,
                Properties = new byte[] { 1,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19721,
                Properties = new byte[] { 1,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19722,
                Properties = new byte[] { 1,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19723,
                Properties = new byte[] { 1,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19724,
                Properties = new byte[] { 1,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19725,
                Properties = new byte[] { 1,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19726,
                Properties = new byte[] { 1,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19727,
                Properties = new byte[] { 1,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19728,
                Properties = new byte[] { 1,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19729,
                Properties = new byte[] { 1,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19730,
                Properties = new byte[] { 1,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19731,
                Properties = new byte[] { 1,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19732,
                Properties = new byte[] { 1,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19733,
                Properties = new byte[] { 1,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19734,
                Properties = new byte[] { 1,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19735,
                Properties = new byte[] { 1,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19736,
                Properties = new byte[] { 1,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19737,
                Properties = new byte[] { 1,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19738,
                Properties = new byte[] { 1,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19739,
                Properties = new byte[] { 1,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19740,
                Properties = new byte[] { 1,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19741,
                Properties = new byte[] { 1,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19742,
                Properties = new byte[] { 1,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19743,
                Properties = new byte[] { 1,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19744,
                Properties = new byte[] { 1,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19745,
                Properties = new byte[] { 1,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19746,
                Properties = new byte[] { 1,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19747,
                Properties = new byte[] { 1,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19748,
                Properties = new byte[] { 1,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19749,
                Properties = new byte[] { 1,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19750,
                Properties = new byte[] { 1,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19751,
                Properties = new byte[] { 1,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19752,
                Properties = new byte[] { 1,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19753,
                Properties = new byte[] { 1,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19754,
                Properties = new byte[] { 1,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19755,
                Properties = new byte[] { 1,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19756,
                Properties = new byte[] { 1,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19757,
                Properties = new byte[] { 1,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19758,
                Properties = new byte[] { 1,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19759,
                Properties = new byte[] { 1,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19760,
                Properties = new byte[] { 1,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19761,
                Properties = new byte[] { 1,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19762,
                Properties = new byte[] { 1,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19763,
                Properties = new byte[] { 1,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19764,
                Properties = new byte[] { 1,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19765,
                Properties = new byte[] { 1,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19766,
                Properties = new byte[] { 1,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19767,
                Properties = new byte[] { 1,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19768,
                Properties = new byte[] { 1,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19769,
                Properties = new byte[] { 1,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19770,
                Properties = new byte[] { 1,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19771,
                Properties = new byte[] { 1,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19772,
                Properties = new byte[] { 1,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19773,
                Properties = new byte[] { 1,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19774,
                Properties = new byte[] { 1,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19775,
                Properties = new byte[] { 1,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19776,
                Properties = new byte[] { 1,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19777,
                Properties = new byte[] { 1,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19778,
                Properties = new byte[] { 1,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19779,
                Properties = new byte[] { 1,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19780,
                Properties = new byte[] { 1,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19781,
                Properties = new byte[] { 1,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19782,
                Properties = new byte[] { 1,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19783,
                Properties = new byte[] { 1,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19784,
                Properties = new byte[] { 1,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19785,
                Properties = new byte[] { 1,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19786,
                Properties = new byte[] { 1,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19787,
                Properties = new byte[] { 1,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19788,
                Properties = new byte[] { 1,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19789,
                Properties = new byte[] { 1,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19790,
                Properties = new byte[] { 1,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19791,
                Properties = new byte[] { 1,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19792,
                Properties = new byte[] { 1,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19793,
                Properties = new byte[] { 1,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19794,
                Properties = new byte[] { 1,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19795,
                Properties = new byte[] { 1,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19796,
                Properties = new byte[] { 1,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19797,
                Properties = new byte[] { 1,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19798,
                Properties = new byte[] { 1,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19799,
                Properties = new byte[] { 1,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19800,
                Properties = new byte[] { 1,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19801,
                Properties = new byte[] { 1,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19802,
                Properties = new byte[] { 1,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19803,
                Properties = new byte[] { 1,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19804,
                Properties = new byte[] { 1,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19805,
                Properties = new byte[] { 1,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19806,
                Properties = new byte[] { 1,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19807,
                Properties = new byte[] { 1,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19808,
                Properties = new byte[] { 1,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19809,
                Properties = new byte[] { 1,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19810,
                Properties = new byte[] { 1,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19811,
                Properties = new byte[] { 2,0,0,0,0,0 },
                CollisionShape = 460,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19812,
                Properties = new byte[] { 2,0,0,0,0,1 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19813,
                Properties = new byte[] { 2,0,0,0,0,2 },
                CollisionShape = 463,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19814,
                Properties = new byte[] { 2,0,0,0,1,0 },
                CollisionShape = 460,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19815,
                Properties = new byte[] { 2,0,0,0,1,1 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19816,
                Properties = new byte[] { 2,0,0,0,1,2 },
                CollisionShape = 463,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19817,
                Properties = new byte[] { 2,0,0,1,0,0 },
                CollisionShape = 467,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19818,
                Properties = new byte[] { 2,0,0,1,0,1 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19819,
                Properties = new byte[] { 2,0,0,1,0,2 },
                CollisionShape = 470,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19820,
                Properties = new byte[] { 2,0,0,1,1,0 },
                CollisionShape = 467,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19821,
                Properties = new byte[] { 2,0,0,1,1,1 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19822,
                Properties = new byte[] { 2,0,0,1,1,2 },
                CollisionShape = 470,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19823,
                Properties = new byte[] { 2,0,1,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19824,
                Properties = new byte[] { 2,0,1,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19825,
                Properties = new byte[] { 2,0,1,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19826,
                Properties = new byte[] { 2,0,1,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19827,
                Properties = new byte[] { 2,0,1,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19828,
                Properties = new byte[] { 2,0,1,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19829,
                Properties = new byte[] { 2,0,1,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19830,
                Properties = new byte[] { 2,0,1,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19831,
                Properties = new byte[] { 2,0,1,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19832,
                Properties = new byte[] { 2,0,1,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19833,
                Properties = new byte[] { 2,0,1,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19834,
                Properties = new byte[] { 2,0,1,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19835,
                Properties = new byte[] { 2,0,2,0,0,0 },
                CollisionShape = 472,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19836,
                Properties = new byte[] { 2,0,2,0,0,1 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19837,
                Properties = new byte[] { 2,0,2,0,0,2 },
                CollisionShape = 475,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19838,
                Properties = new byte[] { 2,0,2,0,1,0 },
                CollisionShape = 472,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19839,
                Properties = new byte[] { 2,0,2,0,1,1 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19840,
                Properties = new byte[] { 2,0,2,0,1,2 },
                CollisionShape = 475,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19841,
                Properties = new byte[] { 2,0,2,1,0,0 },
                CollisionShape = 479,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19842,
                Properties = new byte[] { 2,0,2,1,0,1 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19843,
                Properties = new byte[] { 2,0,2,1,0,2 },
                CollisionShape = 482,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19844,
                Properties = new byte[] { 2,0,2,1,1,0 },
                CollisionShape = 479,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19845,
                Properties = new byte[] { 2,0,2,1,1,1 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19846,
                Properties = new byte[] { 2,0,2,1,1,2 },
                CollisionShape = 482,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19847,
                Properties = new byte[] { 2,1,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19848,
                Properties = new byte[] { 2,1,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19849,
                Properties = new byte[] { 2,1,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19850,
                Properties = new byte[] { 2,1,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19851,
                Properties = new byte[] { 2,1,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19852,
                Properties = new byte[] { 2,1,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19853,
                Properties = new byte[] { 2,1,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19854,
                Properties = new byte[] { 2,1,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19855,
                Properties = new byte[] { 2,1,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19856,
                Properties = new byte[] { 2,1,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19857,
                Properties = new byte[] { 2,1,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19858,
                Properties = new byte[] { 2,1,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19859,
                Properties = new byte[] { 2,1,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19860,
                Properties = new byte[] { 2,1,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19861,
                Properties = new byte[] { 2,1,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19862,
                Properties = new byte[] { 2,1,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19863,
                Properties = new byte[] { 2,1,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19864,
                Properties = new byte[] { 2,1,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19865,
                Properties = new byte[] { 2,1,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19866,
                Properties = new byte[] { 2,1,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19867,
                Properties = new byte[] { 2,1,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19868,
                Properties = new byte[] { 2,1,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19869,
                Properties = new byte[] { 2,1,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19870,
                Properties = new byte[] { 2,1,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19871,
                Properties = new byte[] { 2,1,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19872,
                Properties = new byte[] { 2,1,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19873,
                Properties = new byte[] { 2,1,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19874,
                Properties = new byte[] { 2,1,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19875,
                Properties = new byte[] { 2,1,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19876,
                Properties = new byte[] { 2,1,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19877,
                Properties = new byte[] { 2,1,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19878,
                Properties = new byte[] { 2,1,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19879,
                Properties = new byte[] { 2,1,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19880,
                Properties = new byte[] { 2,1,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19881,
                Properties = new byte[] { 2,1,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19882,
                Properties = new byte[] { 2,1,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19883,
                Properties = new byte[] { 2,2,0,0,0,0 },
                CollisionShape = 492,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19884,
                Properties = new byte[] { 2,2,0,0,0,1 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19885,
                Properties = new byte[] { 2,2,0,0,0,2 },
                CollisionShape = 495,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19886,
                Properties = new byte[] { 2,2,0,0,1,0 },
                CollisionShape = 492,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19887,
                Properties = new byte[] { 2,2,0,0,1,1 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19888,
                Properties = new byte[] { 2,2,0,0,1,2 },
                CollisionShape = 495,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19889,
                Properties = new byte[] { 2,2,0,1,0,0 },
                CollisionShape = 499,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19890,
                Properties = new byte[] { 2,2,0,1,0,1 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19891,
                Properties = new byte[] { 2,2,0,1,0,2 },
                CollisionShape = 502,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19892,
                Properties = new byte[] { 2,2,0,1,1,0 },
                CollisionShape = 499,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19893,
                Properties = new byte[] { 2,2,0,1,1,1 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19894,
                Properties = new byte[] { 2,2,0,1,1,2 },
                CollisionShape = 502,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19895,
                Properties = new byte[] { 2,2,1,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19896,
                Properties = new byte[] { 2,2,1,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19897,
                Properties = new byte[] { 2,2,1,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19898,
                Properties = new byte[] { 2,2,1,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19899,
                Properties = new byte[] { 2,2,1,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19900,
                Properties = new byte[] { 2,2,1,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19901,
                Properties = new byte[] { 2,2,1,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19902,
                Properties = new byte[] { 2,2,1,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19903,
                Properties = new byte[] { 2,2,1,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19904,
                Properties = new byte[] { 2,2,1,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19905,
                Properties = new byte[] { 2,2,1,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19906,
                Properties = new byte[] { 2,2,1,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19907,
                Properties = new byte[] { 2,2,2,0,0,0 },
                CollisionShape = 506,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19908,
                Properties = new byte[] { 2,2,2,0,0,1 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19909,
                Properties = new byte[] { 2,2,2,0,0,2 },
                CollisionShape = 509,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19910,
                Properties = new byte[] { 2,2,2,0,1,0 },
                CollisionShape = 506,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19911,
                Properties = new byte[] { 2,2,2,0,1,1 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19912,
                Properties = new byte[] { 2,2,2,0,1,2 },
                CollisionShape = 509,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19913,
                Properties = new byte[] { 2,2,2,1,0,0 },
                CollisionShape = 513,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19914,
                Properties = new byte[] { 2,2,2,1,0,1 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19915,
                Properties = new byte[] { 2,2,2,1,0,2 },
                CollisionShape = 516,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19916,
                Properties = new byte[] { 2,2,2,1,1,0 },
                CollisionShape = 513,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19917,
                Properties = new byte[] { 2,2,2,1,1,1 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 19918,
                Properties = new byte[] { 2,2,2,1,1,2 },
                CollisionShape = 516,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
