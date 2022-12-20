using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.podzol)]
    public class podzol : IBlockData
    {
        public short DefaultStateID => 13;
        public state DefaultState => States[1];
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 1;
        public short DroppedItem => 17;
        public MinecraftMaterial Material => MinecraftMaterial.soil;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "snowy", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 12,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 13,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
