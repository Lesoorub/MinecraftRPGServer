using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.spruce_leaves)]
    public class spruce_leaves : IBlockData
    {
        public short DefaultStateID => 175;
        public state DefaultState => States[13];
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 2;
        public short DroppedItem => 134;
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
                Id = 162,
                Properties = new byte[] { 0,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 163,
                Properties = new byte[] { 0,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 164,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 165,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 166,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 167,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 168,
                Properties = new byte[] { 3,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 169,
                Properties = new byte[] { 3,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 170,
                Properties = new byte[] { 4,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 171,
                Properties = new byte[] { 4,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 172,
                Properties = new byte[] { 5,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 173,
                Properties = new byte[] { 5,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 174,
                Properties = new byte[] { 6,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 175,
                Properties = new byte[] { 6,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
