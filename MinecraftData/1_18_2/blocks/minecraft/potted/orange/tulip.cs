using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.potted_orange_tulip)]
    public class potted_orange_tulip : IBlockData
    {
        public short DefaultStateID => 6525;
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
                Id = 6525,
                Properties = new byte[] {  },
                CollisionShape = 40,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
