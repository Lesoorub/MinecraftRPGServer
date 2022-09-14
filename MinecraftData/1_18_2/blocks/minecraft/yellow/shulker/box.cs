using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.yellow_shulker_box)]
    public class yellow_shulker_box : IBlockData
    {
        public short DefaultStateID => 9556;
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 456;
        public MinecraftMaterial Material => MinecraftMaterial.shulker_box;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9552,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9553,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9554,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9555,
                Properties = new byte[] { 3 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9556,
                Properties = new byte[] { 4 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9557,
                Properties = new byte[] { 5 },
                CollisionShape = 0,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
