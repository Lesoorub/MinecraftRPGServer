using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.potted_warped_fungus)]
    public class potted_warped_fungus : IBlockData
    {
        public short DefaultStateID => 16089;
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
                Id = 16089,
                Properties = new byte[] {  },
                CollisionShape = 40,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
