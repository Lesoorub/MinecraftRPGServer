using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.medium_amethyst_bud)]
    public class medium_amethyst_bud : IBlockData
    {
        public short DefaultStateID => 17699;
        public state DefaultState => States[9];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 53;
        public short DroppedItem => 1097;
        public MinecraftMaterial Material => MinecraftMaterial.amethyst;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17690,
                Properties = new byte[] { 0,0 },
                CollisionShape = 753,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17691,
                Properties = new byte[] { 0,1 },
                CollisionShape = 753,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17692,
                Properties = new byte[] { 1,0 },
                CollisionShape = 754,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17693,
                Properties = new byte[] { 1,1 },
                CollisionShape = 754,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17694,
                Properties = new byte[] { 2,0 },
                CollisionShape = 755,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17695,
                Properties = new byte[] { 2,1 },
                CollisionShape = 755,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17696,
                Properties = new byte[] { 3,0 },
                CollisionShape = 756,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17697,
                Properties = new byte[] { 3,1 },
                CollisionShape = 756,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17698,
                Properties = new byte[] { 4,0 },
                CollisionShape = 757,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17699,
                Properties = new byte[] { 4,1 },
                CollisionShape = 757,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17700,
                Properties = new byte[] { 5,0 },
                CollisionShape = 758,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17701,
                Properties = new byte[] { 5,1 },
                CollisionShape = 758,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
