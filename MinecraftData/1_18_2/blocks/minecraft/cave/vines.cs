using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cave_vines)]
    public class cave_vines : IBlockData
    {
        public short DefaultStateID => 18566;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 59;
        public short DroppedItem => 1055;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "age", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25" } },
            { "berries", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18565,
                Properties = new byte[] { 0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18566,
                Properties = new byte[] { 0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18567,
                Properties = new byte[] { 1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18568,
                Properties = new byte[] { 1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18569,
                Properties = new byte[] { 2,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18570,
                Properties = new byte[] { 2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18571,
                Properties = new byte[] { 3,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18572,
                Properties = new byte[] { 3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18573,
                Properties = new byte[] { 4,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18574,
                Properties = new byte[] { 4,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18575,
                Properties = new byte[] { 5,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18576,
                Properties = new byte[] { 5,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18577,
                Properties = new byte[] { 6,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18578,
                Properties = new byte[] { 6,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18579,
                Properties = new byte[] { 7,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18580,
                Properties = new byte[] { 7,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18581,
                Properties = new byte[] { 8,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18582,
                Properties = new byte[] { 8,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18583,
                Properties = new byte[] { 9,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18584,
                Properties = new byte[] { 9,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18585,
                Properties = new byte[] { 10,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18586,
                Properties = new byte[] { 10,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18587,
                Properties = new byte[] { 11,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18588,
                Properties = new byte[] { 11,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18589,
                Properties = new byte[] { 12,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18590,
                Properties = new byte[] { 12,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18591,
                Properties = new byte[] { 13,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18592,
                Properties = new byte[] { 13,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18593,
                Properties = new byte[] { 14,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18594,
                Properties = new byte[] { 14,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18595,
                Properties = new byte[] { 15,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18596,
                Properties = new byte[] { 15,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18597,
                Properties = new byte[] { 16,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18598,
                Properties = new byte[] { 16,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18599,
                Properties = new byte[] { 17,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18600,
                Properties = new byte[] { 17,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18601,
                Properties = new byte[] { 18,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18602,
                Properties = new byte[] { 18,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18603,
                Properties = new byte[] { 19,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18604,
                Properties = new byte[] { 19,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18605,
                Properties = new byte[] { 20,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18606,
                Properties = new byte[] { 20,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18607,
                Properties = new byte[] { 21,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18608,
                Properties = new byte[] { 21,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18609,
                Properties = new byte[] { 22,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18610,
                Properties = new byte[] { 22,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18611,
                Properties = new byte[] { 23,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18612,
                Properties = new byte[] { 23,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18613,
                Properties = new byte[] { 24,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18614,
                Properties = new byte[] { 24,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18615,
                Properties = new byte[] { 25,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18616,
                Properties = new byte[] { 25,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
