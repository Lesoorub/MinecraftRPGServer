using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.soul_lantern)]
    public class soul_lantern : IBlockData
    {
        public short DefaultStateID => 15143;
        public state DefaultState => States[3];
        public float Hardness => 3.5f;
        public float ExplosionResistance => 3.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 25;
        public short DroppedItem => 1053;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "hanging", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15140,
                Properties = new byte[] { 0,0 },
                CollisionShape = 720,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15141,
                Properties = new byte[] { 0,1 },
                CollisionShape = 720,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15142,
                Properties = new byte[] { 1,0 },
                CollisionShape = 721,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15143,
                Properties = new byte[] { 1,1 },
                CollisionShape = 721,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
