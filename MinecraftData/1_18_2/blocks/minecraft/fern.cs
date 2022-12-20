using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.fern)]
    public class fern : IBlockData
    {
        public short DefaultStateID => 1399;
        public state DefaultState => States[0];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 2;
        public short DroppedItem => 151;
        public MinecraftMaterial Material => MinecraftMaterial.replaceable_plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1399,
                Properties = new byte[] {  },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
