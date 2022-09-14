using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.netherrack)]
    public class netherrack : IBlockData
    {
        public short DefaultStateID => 4068;
        public float Hardness => 0.4f;
        public float ExplosionResistance => 0.4f;
        public bool IsTransparent => false;
        public byte SoundGroup => 37;
        public short DroppedItem => 268;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4068,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
