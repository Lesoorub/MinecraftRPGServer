using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.carved_pumpkin)]
    public class carved_pumpkin : IBlockData
    {
        public short DefaultStateID => 4085;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 266;
        public MinecraftMaterial Material => MinecraftMaterial.gourd;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 4085,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4086,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4087,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 4088,
                Properties = new byte[] { 3 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
