using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.gray_carpet)]
    public class gray_carpet : IBlockData
    {
        public short DefaultStateID => 8123;
        public state DefaultState => States[0];
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 7;
        public short DroppedItem => 380;
        public MinecraftMaterial Material => MinecraftMaterial.carpet;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 8123,
                Properties = new byte[] {  },
                CollisionShape = 77,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
