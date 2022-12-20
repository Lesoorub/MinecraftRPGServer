using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.white_shulker_box)]
    public class white_shulker_box : IBlockData
    {
        public short DefaultStateID => 9532;
        public state DefaultState => States[4];
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 452;
        public MinecraftMaterial Material => MinecraftMaterial.shulker_box;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9528,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9529,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9530,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9531,
                Properties = new byte[] { 3 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9532,
                Properties = new byte[] { 4 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9533,
                Properties = new byte[] { 5 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
