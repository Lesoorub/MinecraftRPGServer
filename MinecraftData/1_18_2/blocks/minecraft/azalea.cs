using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.azalea)]
    public class azalea : IBlockData
    {
        public short DefaultStateID => 18620;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 61;
        public short DroppedItem => 152;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18620,
                Properties = new byte[] {  },
                CollisionShape = 768,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
