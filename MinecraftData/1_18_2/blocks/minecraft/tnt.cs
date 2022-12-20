using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.tnt)]
    public class tnt : IBlockData
    {
        public short DefaultStateID => 1487;
        public state DefaultState => States[1];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => false;
        public byte SoundGroup => 2;
        public short DroppedItem => 606;
        public MinecraftMaterial Material => MinecraftMaterial.tnt;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "unstable", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1486,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1487,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
