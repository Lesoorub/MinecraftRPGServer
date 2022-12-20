using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.end_rod)]
    public class end_rod : IBlockData
    {
        public short DefaultStateID => 9312;
        public state DefaultState => States[4];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 237;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9308,
                Properties = new byte[] { 0 },
                CollisionShape = 20,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9309,
                Properties = new byte[] { 1 },
                CollisionShape = 24,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9310,
                Properties = new byte[] { 2 },
                CollisionShape = 20,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9311,
                Properties = new byte[] { 3 },
                CollisionShape = 24,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9312,
                Properties = new byte[] { 4 },
                CollisionShape = 33,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9313,
                Properties = new byte[] { 5 },
                CollisionShape = 33,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
