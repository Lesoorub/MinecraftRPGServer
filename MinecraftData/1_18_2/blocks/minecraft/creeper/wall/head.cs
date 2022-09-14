using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.creeper_wall_head)]
    public class creeper_wall_head : IBlockData
    {
        public short DefaultStateID => 6792;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 957;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6792,
                Properties = new byte[] { 0 },
                CollisionShape = 585,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6793,
                Properties = new byte[] { 1 },
                CollisionShape = 587,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6794,
                Properties = new byte[] { 2 },
                CollisionShape = 588,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6795,
                Properties = new byte[] { 3 },
                CollisionShape = 590,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
