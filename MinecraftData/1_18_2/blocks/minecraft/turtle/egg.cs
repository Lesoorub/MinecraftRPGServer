using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.turtle_egg)]
    public class turtle_egg : IBlockData
    {
        public short DefaultStateID => 9748;
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 5;
        public short DroppedItem => 516;
        public MinecraftMaterial Material => MinecraftMaterial.egg;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "eggs", new List<string>() { "1", "2", "3", "4" } },
            { "hatch", new List<string>() { "0", "1", "2" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9748,
                Properties = new byte[] { 0,0 },
                CollisionShape = 672,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9749,
                Properties = new byte[] { 0,1 },
                CollisionShape = 672,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9750,
                Properties = new byte[] { 0,2 },
                CollisionShape = 672,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9751,
                Properties = new byte[] { 1,0 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9752,
                Properties = new byte[] { 1,1 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9753,
                Properties = new byte[] { 1,2 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9754,
                Properties = new byte[] { 2,0 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9755,
                Properties = new byte[] { 2,1 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9756,
                Properties = new byte[] { 2,2 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9757,
                Properties = new byte[] { 3,0 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9758,
                Properties = new byte[] { 3,1 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9759,
                Properties = new byte[] { 3,2 },
                CollisionShape = 673,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
