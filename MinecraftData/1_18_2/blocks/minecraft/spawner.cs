using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.spawner)]
    public class spawner : IBlockData
    {
        public short DefaultStateID => 2009;
        public state DefaultState => States[0];
        public float Hardness => 5f;
        public float ExplosionResistance => 5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 5;
        public short DroppedItem => 243;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 2009,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
