using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.deepslate_brick_slab)]
    public class deepslate_brick_slab : IBlockData
    {
        public short DefaultStateID => 20003;
        public float Hardness => 3.5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 73;
        public short DroppedItem => 582;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "type", new List<string>() { "top", "bottom", "double" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 20000,
                Properties = new byte[] { 0,0 },
                CollisionShape = 80,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 20001,
                Properties = new byte[] { 0,1 },
                CollisionShape = 80,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 20002,
                Properties = new byte[] { 1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 20003,
                Properties = new byte[] { 1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 20004,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 20005,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
