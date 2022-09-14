using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.snow)]
    public class snow : IBlockData
    {
        public short DefaultStateID => 3990;
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 9;
        public short DroppedItem => 251;
        public MinecraftMaterial Material => MinecraftMaterial.snow_layer;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "layers", new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 3990,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3991,
                Properties = new byte[] { 1 },
                CollisionShape = 6,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3992,
                Properties = new byte[] { 2 },
                CollisionShape = 37,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3993,
                Properties = new byte[] { 3 },
                CollisionShape = 208,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3994,
                Properties = new byte[] { 4 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3995,
                Properties = new byte[] { 5 },
                CollisionShape = 209,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3996,
                Properties = new byte[] { 6 },
                CollisionShape = 13,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 3997,
                Properties = new byte[] { 7 },
                CollisionShape = 210,
                LightCost = 15,
                HasSideTransparency = true,
            }
        };
    }
}
