using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.bone_block)]
    public class bone_block : IBlockData
    {
        public short DefaultStateID => 9507;
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => false;
        public byte SoundGroup => 41;
        public short DroppedItem => 449;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "axis", new List<string>() { "x", "y", "z" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9506,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9507,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9508,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
