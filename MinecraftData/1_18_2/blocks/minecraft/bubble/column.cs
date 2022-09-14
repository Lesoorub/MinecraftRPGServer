using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.bubble_column)]
    public class bubble_column : IBlockData
    {
        public short DefaultStateID => 9917;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.bubble_column;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "drag", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9917,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9918,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
