using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.flowering_azalea)]
    public class flowering_azalea : IBlockData
    {
        public short DefaultStateID => 18621;
        public state DefaultState => States[0];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 62;
        public short DroppedItem => 153;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18621,
                Properties = new byte[] {  },
                CollisionShape = 768,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
