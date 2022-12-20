using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.nether_portal)]
    public class nether_portal : IBlockData
    {
        public short DefaultStateID => 4083;
        public state DefaultState => States[0];
        public float Hardness => -1f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.portal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "axis", new List<string>() { "x", "z" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4083,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4084,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
