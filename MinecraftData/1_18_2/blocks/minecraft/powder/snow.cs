using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.powder_snow)]
    public class powder_snow : IBlockData
    {
        public short DefaultStateID => 17717;
        public float Hardness => 0.25f;
        public float ExplosionResistance => 0.25f;
        public bool IsTransparent => false;
        public byte SoundGroup => 10;
        public short DroppedItem => 779;
        public MinecraftMaterial Material => MinecraftMaterial.powder_snow;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17717,
                Properties = new byte[] {  },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
