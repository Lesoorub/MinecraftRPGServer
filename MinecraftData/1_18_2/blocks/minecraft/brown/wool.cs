using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.brown_wool)]
    public class brown_wool : IBlockData
    {
        public short DefaultStateID => 1452;
        public state DefaultState => States[0];
        public float Hardness => 0.8f;
        public float ExplosionResistance => 0.8f;
        public bool IsTransparent => false;
        public byte SoundGroup => 7;
        public short DroppedItem => 169;
        public MinecraftMaterial Material => MinecraftMaterial.wool;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1452,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
