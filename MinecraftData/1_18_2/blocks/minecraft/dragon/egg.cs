using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dragon_egg)]
    public class dragon_egg : IBlockData
    {
        public short DefaultStateID => 5360;
        public state DefaultState => States[0];
        public float Hardness => 3f;
        public float ExplosionResistance => 9f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 314;
        public MinecraftMaterial Material => MinecraftMaterial.egg;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5360,
                Properties = new byte[] {  },
                CollisionShape = 116,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
