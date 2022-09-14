using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.potatoes)]
    public class potatoes : IBlockData
    {
        public short DefaultStateID => 6544;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 21;
        public short DroppedItem => 948;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "age", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6544,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6545,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6546,
                Properties = new byte[] { 2 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6547,
                Properties = new byte[] { 3 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6548,
                Properties = new byte[] { 4 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6549,
                Properties = new byte[] { 5 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6550,
                Properties = new byte[] { 6 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6551,
                Properties = new byte[] { 7 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
