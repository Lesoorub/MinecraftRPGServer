using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.chorus_plant)]
    public class chorus_plant : IBlockData
    {
        public short DefaultStateID => 9377;
        public state DefaultState => States[63];
        public float Hardness => 0.4f;
        public float ExplosionResistance => 0.4f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 238;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "down", new List<string>() { "True", "False" } },
            { "east", new List<string>() { "True", "False" } },
            { "north", new List<string>() { "True", "False" } },
            { "south", new List<string>() { "True", "False" } },
            { "up", new List<string>() { "True", "False" } },
            { "west", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9314,
                Properties = new byte[] { 0,0,0,0,0,0 },
                CollisionShape = 607,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9315,
                Properties = new byte[] { 0,0,0,0,0,1 },
                CollisionShape = 608,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9316,
                Properties = new byte[] { 0,0,0,0,1,0 },
                CollisionShape = 609,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9317,
                Properties = new byte[] { 0,0,0,0,1,1 },
                CollisionShape = 610,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9318,
                Properties = new byte[] { 0,0,0,1,0,0 },
                CollisionShape = 611,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9319,
                Properties = new byte[] { 0,0,0,1,0,1 },
                CollisionShape = 612,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9320,
                Properties = new byte[] { 0,0,0,1,1,0 },
                CollisionShape = 613,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9321,
                Properties = new byte[] { 0,0,0,1,1,1 },
                CollisionShape = 614,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9322,
                Properties = new byte[] { 0,0,1,0,0,0 },
                CollisionShape = 615,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9323,
                Properties = new byte[] { 0,0,1,0,0,1 },
                CollisionShape = 616,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9324,
                Properties = new byte[] { 0,0,1,0,1,0 },
                CollisionShape = 617,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9325,
                Properties = new byte[] { 0,0,1,0,1,1 },
                CollisionShape = 618,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9326,
                Properties = new byte[] { 0,0,1,1,0,0 },
                CollisionShape = 619,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9327,
                Properties = new byte[] { 0,0,1,1,0,1 },
                CollisionShape = 620,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9328,
                Properties = new byte[] { 0,0,1,1,1,0 },
                CollisionShape = 621,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9329,
                Properties = new byte[] { 0,0,1,1,1,1 },
                CollisionShape = 622,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9330,
                Properties = new byte[] { 0,1,0,0,0,0 },
                CollisionShape = 623,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9331,
                Properties = new byte[] { 0,1,0,0,0,1 },
                CollisionShape = 624,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9332,
                Properties = new byte[] { 0,1,0,0,1,0 },
                CollisionShape = 625,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9333,
                Properties = new byte[] { 0,1,0,0,1,1 },
                CollisionShape = 626,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9334,
                Properties = new byte[] { 0,1,0,1,0,0 },
                CollisionShape = 627,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9335,
                Properties = new byte[] { 0,1,0,1,0,1 },
                CollisionShape = 628,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9336,
                Properties = new byte[] { 0,1,0,1,1,0 },
                CollisionShape = 629,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9337,
                Properties = new byte[] { 0,1,0,1,1,1 },
                CollisionShape = 630,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9338,
                Properties = new byte[] { 0,1,1,0,0,0 },
                CollisionShape = 631,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9339,
                Properties = new byte[] { 0,1,1,0,0,1 },
                CollisionShape = 632,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9340,
                Properties = new byte[] { 0,1,1,0,1,0 },
                CollisionShape = 633,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9341,
                Properties = new byte[] { 0,1,1,0,1,1 },
                CollisionShape = 634,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9342,
                Properties = new byte[] { 0,1,1,1,0,0 },
                CollisionShape = 635,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9343,
                Properties = new byte[] { 0,1,1,1,0,1 },
                CollisionShape = 636,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9344,
                Properties = new byte[] { 0,1,1,1,1,0 },
                CollisionShape = 637,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9345,
                Properties = new byte[] { 0,1,1,1,1,1 },
                CollisionShape = 638,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9346,
                Properties = new byte[] { 1,0,0,0,0,0 },
                CollisionShape = 639,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9347,
                Properties = new byte[] { 1,0,0,0,0,1 },
                CollisionShape = 640,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9348,
                Properties = new byte[] { 1,0,0,0,1,0 },
                CollisionShape = 641,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9349,
                Properties = new byte[] { 1,0,0,0,1,1 },
                CollisionShape = 642,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9350,
                Properties = new byte[] { 1,0,0,1,0,0 },
                CollisionShape = 643,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9351,
                Properties = new byte[] { 1,0,0,1,0,1 },
                CollisionShape = 644,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9352,
                Properties = new byte[] { 1,0,0,1,1,0 },
                CollisionShape = 645,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9353,
                Properties = new byte[] { 1,0,0,1,1,1 },
                CollisionShape = 646,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9354,
                Properties = new byte[] { 1,0,1,0,0,0 },
                CollisionShape = 647,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9355,
                Properties = new byte[] { 1,0,1,0,0,1 },
                CollisionShape = 648,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9356,
                Properties = new byte[] { 1,0,1,0,1,0 },
                CollisionShape = 649,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9357,
                Properties = new byte[] { 1,0,1,0,1,1 },
                CollisionShape = 650,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9358,
                Properties = new byte[] { 1,0,1,1,0,0 },
                CollisionShape = 651,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9359,
                Properties = new byte[] { 1,0,1,1,0,1 },
                CollisionShape = 652,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9360,
                Properties = new byte[] { 1,0,1,1,1,0 },
                CollisionShape = 653,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9361,
                Properties = new byte[] { 1,0,1,1,1,1 },
                CollisionShape = 654,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9362,
                Properties = new byte[] { 1,1,0,0,0,0 },
                CollisionShape = 655,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9363,
                Properties = new byte[] { 1,1,0,0,0,1 },
                CollisionShape = 656,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9364,
                Properties = new byte[] { 1,1,0,0,1,0 },
                CollisionShape = 657,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9365,
                Properties = new byte[] { 1,1,0,0,1,1 },
                CollisionShape = 658,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9366,
                Properties = new byte[] { 1,1,0,1,0,0 },
                CollisionShape = 659,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9367,
                Properties = new byte[] { 1,1,0,1,0,1 },
                CollisionShape = 660,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9368,
                Properties = new byte[] { 1,1,0,1,1,0 },
                CollisionShape = 661,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9369,
                Properties = new byte[] { 1,1,0,1,1,1 },
                CollisionShape = 662,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9370,
                Properties = new byte[] { 1,1,1,0,0,0 },
                CollisionShape = 663,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9371,
                Properties = new byte[] { 1,1,1,0,0,1 },
                CollisionShape = 664,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9372,
                Properties = new byte[] { 1,1,1,0,1,0 },
                CollisionShape = 665,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9373,
                Properties = new byte[] { 1,1,1,0,1,1 },
                CollisionShape = 666,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9374,
                Properties = new byte[] { 1,1,1,1,0,0 },
                CollisionShape = 667,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9375,
                Properties = new byte[] { 1,1,1,1,0,1 },
                CollisionShape = 668,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9376,
                Properties = new byte[] { 1,1,1,1,1,0 },
                CollisionShape = 669,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9377,
                Properties = new byte[] { 1,1,1,1,1,1 },
                CollisionShape = 670,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
