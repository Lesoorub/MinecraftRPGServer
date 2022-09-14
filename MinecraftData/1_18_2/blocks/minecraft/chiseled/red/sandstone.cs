using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.chiseled_red_sandstone)]
    public class chiseled_red_sandstone : IBlockData
    {
        public short DefaultStateID => 8468;
        public float Hardness => 0.8f;
        public float ExplosionResistance => 0.8f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 440;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 8468,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
