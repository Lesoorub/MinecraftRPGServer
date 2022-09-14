using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dark_oak_slab)]
    public class dark_oak_slab : IBlockData
    {
        public short DefaultStateID => 8583;
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 209;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "type", new List<string>() { "top", "bottom", "double" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 8580,
                Properties = new byte[] { 0,0 },
                CollisionShape = 80,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8581,
                Properties = new byte[] { 0,1 },
                CollisionShape = 80,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8582,
                Properties = new byte[] { 1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8583,
                Properties = new byte[] { 1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 8584,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8585,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
