using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.water_cauldron)]
    public class water_cauldron : IBlockData
    {
        public short DefaultStateID => 5343;
        public state DefaultState => States[0];
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 870;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "level", new List<string>() { "1", "2", "3" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5343,
                Properties = new byte[] { 0 },
                CollisionShape = 370,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5344,
                Properties = new byte[] { 1 },
                CollisionShape = 370,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5345,
                Properties = new byte[] { 2 },
                CollisionShape = 370,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
