using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.damaged_anvil)]
    public class damaged_anvil : IBlockData
    {
        public short DefaultStateID => 6824;
        public float Hardness => 5f;
        public float ExplosionResistance => 1200f;
        public bool IsTransparent => false;
        public byte SoundGroup => 12;
        public short DroppedItem => 348;
        public MinecraftMaterial Material => MinecraftMaterial.repair_station;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6824,
                Properties = new byte[] { 0 },
                CollisionShape = 591,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6825,
                Properties = new byte[] { 1 },
                CollisionShape = 591,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6826,
                Properties = new byte[] { 2 },
                CollisionShape = 594,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6827,
                Properties = new byte[] { 3 },
                CollisionShape = 594,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
