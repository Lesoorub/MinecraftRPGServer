using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.dead_tube_coral_wall_fan)]
    public class dead_tube_coral_wall_fan : IBlockData
    {
        public short DefaultStateID => 9810;
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 542;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9810,
                Properties = new byte[] { 0,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9811,
                Properties = new byte[] { 0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9812,
                Properties = new byte[] { 1,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9813,
                Properties = new byte[] { 1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9814,
                Properties = new byte[] { 2,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9815,
                Properties = new byte[] { 2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9816,
                Properties = new byte[] { 3,0 },
                CollisionShape = null,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9817,
                Properties = new byte[] { 3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
