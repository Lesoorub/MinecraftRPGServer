using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.large_fern)]
    public class large_fern : IBlockData
    {
        public short DefaultStateID => 8146;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 2;
        public short DroppedItem => 399;
        public MinecraftMaterial Material => MinecraftMaterial.replaceable_plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "half", new List<string>() { "upper", "lower" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 8145,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8146,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
