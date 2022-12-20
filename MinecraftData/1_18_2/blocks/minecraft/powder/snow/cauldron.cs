using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.powder_snow_cauldron)]
    public class powder_snow_cauldron : IBlockData
    {
        public short DefaultStateID => 5347;
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
                Id = 5347,
                Properties = new byte[] { 0 },
                CollisionShape = 370,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5348,
                Properties = new byte[] { 1 },
                CollisionShape = 370,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5349,
                Properties = new byte[] { 2 },
                CollisionShape = 370,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
