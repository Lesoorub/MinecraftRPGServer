using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.warped_wart_block)]
    public class warped_wart_block : IBlockData
    {
        public short DefaultStateID => 15226;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 36;
        public short DroppedItem => 447;
        public MinecraftMaterial Material => MinecraftMaterial.solid_organic;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15226,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
