using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.waxed_cut_copper_slab)]
    public class waxed_cut_copper_slab : IBlockData
    {
        public short DefaultStateID => 18517;
        public state DefaultState => States[3];
        public float Hardness => 3f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 58;
        public short DroppedItem => 97;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "type", new List<string>() { "top", "bottom", "double" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18514,
                Properties = new byte[] { 0,0 },
                CollisionShape = 80,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 18515,
                Properties = new byte[] { 0,1 },
                CollisionShape = 80,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 18516,
                Properties = new byte[] { 1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 18517,
                Properties = new byte[] { 1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 18518,
                Properties = new byte[] { 2,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18519,
                Properties = new byte[] { 2,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
