using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cartography_table)]
    public class cartography_table : IBlockData
    {
        public short DefaultStateID => 15069;
        public float Hardness => 2.5f;
        public float ExplosionResistance => 2.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 1046;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15069,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
