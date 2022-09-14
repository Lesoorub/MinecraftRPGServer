using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.end_gateway)]
    public class end_gateway : IBlockData
    {
        public short DefaultStateID => 9474;
        public float Hardness => -1f;
        public float ExplosionResistance => 3600000f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.portal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9474,
                Properties = new byte[] {  },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
