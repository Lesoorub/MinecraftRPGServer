using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.hanging_roots)]
    public class hanging_roots : IBlockData
    {
        public short DefaultStateID => 18681;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 68;
        public short DroppedItem => 200;
        public MinecraftMaterial Material => MinecraftMaterial.replaceable_plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18680,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18681,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
