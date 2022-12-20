using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.potted_flowering_azalea_bush)]
    public class potted_flowering_azalea_bush : IBlockData
    {
        public short DefaultStateID => 20341;
        public state DefaultState => States[0];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 20341,
                Properties = new byte[] {  },
                CollisionShape = 40,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
