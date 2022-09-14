using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.structure_block)]
    public class structure_block : IBlockData
    {
        public short DefaultStateID => 15990;
        public float Hardness => -1f;
        public float ExplosionResistance => 3600000f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 676;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "mode", new List<string>() { "save", "load", "corner", "data" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15989,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15990,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15991,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15992,
                Properties = new byte[] { 3 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
