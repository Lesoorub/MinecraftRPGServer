using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.zombie_wall_head)]
    public class zombie_wall_head : IBlockData
    {
        public short DefaultStateID => 6752;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 956;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6752,
                Properties = new byte[] { 0 },
                CollisionShape = 585,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6753,
                Properties = new byte[] { 1 },
                CollisionShape = 587,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6754,
                Properties = new byte[] { 2 },
                CollisionShape = 588,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6755,
                Properties = new byte[] { 3 },
                CollisionShape = 590,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
