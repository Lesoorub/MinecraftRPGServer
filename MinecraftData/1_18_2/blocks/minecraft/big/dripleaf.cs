using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.big_dripleaf)]
    public class big_dripleaf : IBlockData
    {
        public short DefaultStateID => 18625;
        public state DefaultState => States[1];
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 65;
        public short DroppedItem => 201;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "tilt", new List<string>() { "none", "unstable", "partial", "full" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18624,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18625,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18626,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18627,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18628,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = 772,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18629,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = 772,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18630,
                Properties = new byte[] { 0,3,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18631,
                Properties = new byte[] { 0,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18632,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18633,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18634,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18635,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18636,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = 772,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18637,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = 772,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18638,
                Properties = new byte[] { 1,3,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18639,
                Properties = new byte[] { 1,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18640,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18641,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18642,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18643,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18644,
                Properties = new byte[] { 2,2,0 },
                CollisionShape = 772,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18645,
                Properties = new byte[] { 2,2,1 },
                CollisionShape = 772,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18646,
                Properties = new byte[] { 2,3,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18647,
                Properties = new byte[] { 2,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18648,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18649,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18650,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 769,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18651,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 769,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18652,
                Properties = new byte[] { 3,2,0 },
                CollisionShape = 772,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18653,
                Properties = new byte[] { 3,2,1 },
                CollisionShape = 772,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18654,
                Properties = new byte[] { 3,3,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18655,
                Properties = new byte[] { 3,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
