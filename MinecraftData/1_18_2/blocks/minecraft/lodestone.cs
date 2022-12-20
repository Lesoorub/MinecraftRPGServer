using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.lodestone)]
    public class lodestone : IBlockData
    {
        public short DefaultStateID => 16092;
        public state DefaultState => States[0];
        public float Hardness => 3.5f;
        public float ExplosionResistance => 3.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 44;
        public short DroppedItem => 1064;
        public MinecraftMaterial Material => MinecraftMaterial.repair_station;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 16092,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
