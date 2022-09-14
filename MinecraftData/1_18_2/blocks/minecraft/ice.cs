using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.ice)]
    public class ice : IBlockData
    {
        public short DefaultStateID => 3998;
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 252;
        public MinecraftMaterial Material => MinecraftMaterial.ice;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 3998,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
