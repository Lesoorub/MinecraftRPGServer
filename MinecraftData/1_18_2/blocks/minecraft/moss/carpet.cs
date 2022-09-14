using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.moss_carpet)]
    public class moss_carpet : IBlockData
    {
        public short DefaultStateID => 18622;
        public float Hardness => 0.1f;
        public float ExplosionResistance => 0.1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 63;
        public short DroppedItem => 198;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18622,
                Properties = new byte[] {  },
                CollisionShape = 77,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
