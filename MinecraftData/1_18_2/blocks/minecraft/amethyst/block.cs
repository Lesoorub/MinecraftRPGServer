using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.amethyst_block)]
    public class amethyst_block : IBlockData
    {
        public short DefaultStateID => 17664;
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 49;
        public short DroppedItem => 63;
        public MinecraftMaterial Material => MinecraftMaterial.amethyst;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17664,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
