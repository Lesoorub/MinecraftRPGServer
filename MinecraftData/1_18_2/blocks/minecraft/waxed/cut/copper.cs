using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.waxed_cut_copper)]
    public class waxed_cut_copper : IBlockData
    {
        public short DefaultStateID => 18175;
        public state DefaultState => States[0];
        public float Hardness => 3f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 58;
        public short DroppedItem => 89;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18175,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
