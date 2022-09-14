using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.oak_leaves)]
    public class oak_leaves : IBlockData
    {
        public short DefaultStateID => 161;
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 2;
        public short DroppedItem => 133;
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
                Id = 148,
                Properties = new byte[] { 0,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 149,
                Properties = new byte[] { 0,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 150,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 151,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 152,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 153,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 154,
                Properties = new byte[] { 3,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 155,
                Properties = new byte[] { 3,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 156,
                Properties = new byte[] { 4,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 157,
                Properties = new byte[] { 4,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 158,
                Properties = new byte[] { 5,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 159,
                Properties = new byte[] { 5,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 160,
                Properties = new byte[] { 6,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 161,
                Properties = new byte[] { 6,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
