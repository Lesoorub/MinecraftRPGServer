using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.sponge)]
    public class sponge : IBlockData
    {
        public short DefaultStateID => 260;
        public float Hardness => 0.6f;
        public float ExplosionResistance => 0.6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 2;
        public short DroppedItem => 141;
        public MinecraftMaterial Material => MinecraftMaterial.sponge;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 260,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
