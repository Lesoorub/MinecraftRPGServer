using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.acacia_leaves)]
    public class acacia_leaves : IBlockData
    {
        public short DefaultStateID => 217;
        public state DefaultState => States[13];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 2;
        public short DroppedItem => 137;
        public MinecraftMaterial Material => MinecraftMaterial.leaves;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "distance", new List<string>() { "1", "2", "3", "4", "5", "6", "7" } },
            { "persistent", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 204,
                Properties = new byte[] { 0,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 205,
                Properties = new byte[] { 0,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 206,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 207,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 208,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 209,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 210,
                Properties = new byte[] { 3,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 211,
                Properties = new byte[] { 3,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 212,
                Properties = new byte[] { 4,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 213,
                Properties = new byte[] { 4,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 214,
                Properties = new byte[] { 5,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 215,
                Properties = new byte[] { 5,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 216,
                Properties = new byte[] { 6,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 217,
                Properties = new byte[] { 6,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
