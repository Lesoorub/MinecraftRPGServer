using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.barrier)]
    public class barrier : IBlockData
    {
        public short DefaultStateID => 7754;
        public float Hardness => -1f;
        public float ExplosionResistance => 3600001f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 370;
        public MinecraftMaterial Material => MinecraftMaterial.barrier;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 7754,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
