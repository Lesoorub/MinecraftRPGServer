using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.ladder)]
    public class ladder : IBlockData
    {
        public short DefaultStateID => 3695;
        public float Hardness => 0.4f;
        public float ExplosionResistance => 0.4f;
        public bool IsTransparent => true;
        public byte SoundGroup => 11;
        public short DroppedItem => 249;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 3694,
                Properties = new byte[] { 0,0 },
                CollisionShape = 214,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 3695,
                Properties = new byte[] { 0,1 },
                CollisionShape = 214,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 3696,
                Properties = new byte[] { 1,0 },
                CollisionShape = 216,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 3697,
                Properties = new byte[] { 1,1 },
                CollisionShape = 216,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 3698,
                Properties = new byte[] { 2,0 },
                CollisionShape = 215,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 3699,
                Properties = new byte[] { 2,1 },
                CollisionShape = 215,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 3700,
                Properties = new byte[] { 3,0 },
                CollisionShape = 213,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 3701,
                Properties = new byte[] { 3,1 },
                CollisionShape = 213,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
