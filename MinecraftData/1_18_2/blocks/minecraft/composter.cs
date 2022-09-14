using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.composter)]
    public class composter : IBlockData
    {
        public short DefaultStateID => 16005;
        public float Hardness => 0.6f;
        public float ExplosionResistance => 0.6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 1042;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "level", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 16005,
                Properties = new byte[] { 0 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16006,
                Properties = new byte[] { 1 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16007,
                Properties = new byte[] { 2 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16008,
                Properties = new byte[] { 3 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16009,
                Properties = new byte[] { 4 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16010,
                Properties = new byte[] { 5 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16011,
                Properties = new byte[] { 6 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16012,
                Properties = new byte[] { 7 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 16013,
                Properties = new byte[] { 8 },
                CollisionShape = 728,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
