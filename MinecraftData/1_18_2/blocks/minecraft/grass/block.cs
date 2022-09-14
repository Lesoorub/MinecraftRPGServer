using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.grass_block)]
    public class grass_block : IBlockData
    {
        public short DefaultStateID => 9;
        public float Hardness => 0.6f;
        public float ExplosionResistance => 0.6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 2;
        public short DroppedItem => 14;
        public MinecraftMaterial Material => MinecraftMaterial.solid_organic;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "snowy", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 8,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
