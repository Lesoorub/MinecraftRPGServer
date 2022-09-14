using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.weeping_vines_plant)]
    public class weeping_vines_plant : IBlockData
    {
        public short DefaultStateID => 15270;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 31;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15270,
                Properties = new byte[] {  },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
