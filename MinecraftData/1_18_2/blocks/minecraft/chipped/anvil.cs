using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.chipped_anvil)]
    public class chipped_anvil : IBlockData
    {
        public short DefaultStateID => 6820;
        public state DefaultState => States[0];
        public float Hardness => 5f;
        public float ExplosionResistance => 1200f;
        public bool IsTransparent => false;
        public byte SoundGroup => 12;
        public short DroppedItem => 347;
        public MinecraftMaterial Material => MinecraftMaterial.repair_station;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6820,
                Properties = new byte[] { 0 },
                CollisionShape = 591,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6821,
                Properties = new byte[] { 1 },
                CollisionShape = 591,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6822,
                Properties = new byte[] { 2 },
                CollisionShape = 594,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6823,
                Properties = new byte[] { 3 },
                CollisionShape = 594,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
