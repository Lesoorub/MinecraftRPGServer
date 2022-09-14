using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.stonecutter)]
    public class stonecutter : IBlockData
    {
        public short DefaultStateID => 15100;
        public float Hardness => 3.5f;
        public float ExplosionResistance => 3.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 1050;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15100,
                Properties = new byte[] { 0 },
                CollisionShape = 583,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15101,
                Properties = new byte[] { 1 },
                CollisionShape = 583,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15102,
                Properties = new byte[] { 2 },
                CollisionShape = 583,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 15103,
                Properties = new byte[] { 3 },
                CollisionShape = 583,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
