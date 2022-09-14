using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.end_stone_bricks)]
    public class end_stone_bricks : IBlockData
    {
        public short DefaultStateID => 9468;
        public float Hardness => 3f;
        public float ExplosionResistance => 9f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 313;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9468,
                Properties = new byte[] {  },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
