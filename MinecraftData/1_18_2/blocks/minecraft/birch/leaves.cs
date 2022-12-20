using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.birch_leaves)]
    public class birch_leaves : IBlockData
    {
        public short DefaultStateID => 189;
        public state DefaultState => States[13];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 2;
        public short DroppedItem => 135;
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
                Id = 176,
                Properties = new byte[] { 0,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 177,
                Properties = new byte[] { 0,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 178,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 179,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 180,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 181,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 182,
                Properties = new byte[] { 3,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 183,
                Properties = new byte[] { 3,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 184,
                Properties = new byte[] { 4,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 185,
                Properties = new byte[] { 4,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 186,
                Properties = new byte[] { 5,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 187,
                Properties = new byte[] { 5,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 188,
                Properties = new byte[] { 6,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 189,
                Properties = new byte[] { 6,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
