using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.amethyst_cluster)]
    public class amethyst_cluster : IBlockData
    {
        public short DefaultStateID => 17675;
        public state DefaultState => States[9];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 50;
        public short DroppedItem => 1099;
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
                Id = 17666,
                Properties = new byte[] { 0,0 },
                CollisionShape = 741,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17667,
                Properties = new byte[] { 0,1 },
                CollisionShape = 741,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17668,
                Properties = new byte[] { 1,0 },
                CollisionShape = 742,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17669,
                Properties = new byte[] { 1,1 },
                CollisionShape = 742,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17670,
                Properties = new byte[] { 2,0 },
                CollisionShape = 743,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17671,
                Properties = new byte[] { 2,1 },
                CollisionShape = 743,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17672,
                Properties = new byte[] { 3,0 },
                CollisionShape = 744,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17673,
                Properties = new byte[] { 3,1 },
                CollisionShape = 744,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17674,
                Properties = new byte[] { 4,0 },
                CollisionShape = 745,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17675,
                Properties = new byte[] { 4,1 },
                CollisionShape = 745,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17676,
                Properties = new byte[] { 5,0 },
                CollisionShape = 746,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17677,
                Properties = new byte[] { 5,1 },
                CollisionShape = 746,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
