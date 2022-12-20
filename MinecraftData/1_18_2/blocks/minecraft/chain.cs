using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.chain)]
    public class chain : IBlockData
    {
        public short DefaultStateID => 4801;
        public state DefaultState => States[3];
        public float Hardness => 5f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => true;
        public byte SoundGroup => 45;
        public short DroppedItem => 296;
        public MinecraftMaterial Material => MinecraftMaterial.metal;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "axis", new List<string>() { "x", "y", "z" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4798,
                Properties = new byte[] { 0,0 },
                CollisionShape = 313,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4799,
                Properties = new byte[] { 0,1 },
                CollisionShape = 313,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4800,
                Properties = new byte[] { 1,0 },
                CollisionShape = 314,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4801,
                Properties = new byte[] { 1,1 },
                CollisionShape = 314,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4802,
                Properties = new byte[] { 2,0 },
                CollisionShape = 315,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4803,
                Properties = new byte[] { 2,1 },
                CollisionShape = 315,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
