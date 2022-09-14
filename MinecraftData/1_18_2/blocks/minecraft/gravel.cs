using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.gravel)]
    public class gravel : IBlockData
    {
        public short DefaultStateID => 68;
        public float Hardness => 0.6f;
        public float ExplosionResistance => 0.6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 1;
        public short DroppedItem => 39;
        public MinecraftMaterial Material => MinecraftMaterial.aggregate;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 68,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
