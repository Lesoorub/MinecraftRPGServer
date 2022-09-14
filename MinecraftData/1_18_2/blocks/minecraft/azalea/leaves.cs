using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.azalea_leaves)]
    public class azalea_leaves : IBlockData
    {
        public short DefaultStateID => 245;
        public float Hardness => 0.2f;
        public float ExplosionResistance => 0.2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 69;
        public short DroppedItem => 139;
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
                Id = 232,
                Properties = new byte[] { 0,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 233,
                Properties = new byte[] { 0,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 234,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 235,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 236,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 237,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 238,
                Properties = new byte[] { 3,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 239,
                Properties = new byte[] { 3,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 240,
                Properties = new byte[] { 4,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 241,
                Properties = new byte[] { 4,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 242,
                Properties = new byte[] { 5,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 243,
                Properties = new byte[] { 5,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 244,
                Properties = new byte[] { 6,0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 245,
                Properties = new byte[] { 6,1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
