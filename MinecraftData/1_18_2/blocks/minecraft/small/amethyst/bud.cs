using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.small_amethyst_bud)]
    public class small_amethyst_bud : IBlockData
    {
        public short DefaultStateID => 17711;
        public state DefaultState => States[9];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 51;
        public short DroppedItem => 1096;
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
                Id = 17702,
                Properties = new byte[] { 0,0 },
                CollisionShape = 759,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17703,
                Properties = new byte[] { 0,1 },
                CollisionShape = 759,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17704,
                Properties = new byte[] { 1,0 },
                CollisionShape = 760,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17705,
                Properties = new byte[] { 1,1 },
                CollisionShape = 760,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17706,
                Properties = new byte[] { 2,0 },
                CollisionShape = 761,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17707,
                Properties = new byte[] { 2,1 },
                CollisionShape = 761,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17708,
                Properties = new byte[] { 3,0 },
                CollisionShape = 762,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17709,
                Properties = new byte[] { 3,1 },
                CollisionShape = 762,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17710,
                Properties = new byte[] { 4,0 },
                CollisionShape = 763,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17711,
                Properties = new byte[] { 4,1 },
                CollisionShape = 763,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17712,
                Properties = new byte[] { 5,0 },
                CollisionShape = 764,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17713,
                Properties = new byte[] { 5,1 },
                CollisionShape = 764,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
