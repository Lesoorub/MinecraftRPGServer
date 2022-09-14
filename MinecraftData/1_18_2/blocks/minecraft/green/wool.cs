using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.green_wool)]
    public class green_wool : IBlockData
    {
        public short DefaultStateID => 1453;
        public float Hardness => 0.8f;
        public float ExplosionResistance => 0.8f;
        public bool IsTransparent => false;
        public byte SoundGroup => 7;
        public short DroppedItem => 170;
        public MinecraftMaterial Material => MinecraftMaterial.wool;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1453,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
