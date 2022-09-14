using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.conduit)]
    public class conduit : IBlockData
    {
        public short DefaultStateID => 9899;
        public float Hardness => 3f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 548;
        public MinecraftMaterial Material => MinecraftMaterial.glass;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9899,
                Properties = new byte[] { 0 },
                CollisionShape = 671,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9900,
                Properties = new byte[] { 1 },
                CollisionShape = 671,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
