using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.farmland)]
    public class farmland : IBlockData
    {
        public short DefaultStateID => 3422;
        public state DefaultState => States[0];
        public float Hardness => 0.6f;
        public float ExplosionResistance => 0.6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 1;
        public short DroppedItem => 247;
        public MinecraftMaterial Material => MinecraftMaterial.soil;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "moisture", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 3422,
                Properties = new byte[] { 0 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3423,
                Properties = new byte[] { 1 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3424,
                Properties = new byte[] { 2 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3425,
                Properties = new byte[] { 3 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3426,
                Properties = new byte[] { 4 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3427,
                Properties = new byte[] { 5 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3428,
                Properties = new byte[] { 6 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3429,
                Properties = new byte[] { 7 },
                CollisionShape = 211,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
