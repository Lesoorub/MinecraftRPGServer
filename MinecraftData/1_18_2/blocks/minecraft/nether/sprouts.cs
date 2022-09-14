using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.nether_sprouts)]
    public class nether_sprouts : IBlockData
    {
        public short DefaultStateID => 15228;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 39;
        public short DroppedItem => 193;
        public MinecraftMaterial Material => MinecraftMaterial.nether_shoots;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15228,
                Properties = new byte[] {  },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
