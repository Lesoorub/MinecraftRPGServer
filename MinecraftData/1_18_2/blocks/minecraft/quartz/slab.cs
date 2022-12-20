using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.quartz_slab)]
    public class quartz_slab : IBlockData
    {
        public short DefaultStateID => 8643;
        public state DefaultState => States[3];
        public float Hardness => 2f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 221;
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
                Id = 8640,
                Properties = new byte[] { 0,0 },
                CollisionShape = 80,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8641,
                Properties = new byte[] { 0,1 },
                CollisionShape = 80,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8642,
                Properties = new byte[] { 1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8643,
                Properties = new byte[] { 1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8644,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8645,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
