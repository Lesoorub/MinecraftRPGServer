using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.wither_skeleton_wall_skull)]
    public class wither_skeleton_wall_skull : IBlockData
    {
        public short DefaultStateID => 6732;
        public state DefaultState => States[0];
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 954;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6732,
                Properties = new byte[] { 0 },
                CollisionShape = 585,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6733,
                Properties = new byte[] { 1 },
                CollisionShape = 587,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6734,
                Properties = new byte[] { 2 },
                CollisionShape = 588,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6735,
                Properties = new byte[] { 3 },
                CollisionShape = 590,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
