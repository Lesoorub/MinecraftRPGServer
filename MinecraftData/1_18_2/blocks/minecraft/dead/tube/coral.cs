using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dead_tube_coral)]
    public class dead_tube_coral : IBlockData
    {
        public short DefaultStateID => 9770;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 536;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9770,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9771,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
