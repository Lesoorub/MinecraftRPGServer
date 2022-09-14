using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.tall_seagrass)]
    public class tall_seagrass : IBlockData
    {
        public short DefaultStateID => 1403;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 15;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.replaceable_underwater_plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "half", new List<string>() { "upper", "lower" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1402,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1403,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
