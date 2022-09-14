using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.ender_chest)]
    public class ender_chest : IBlockData
    {
        public short DefaultStateID => 5458;
        public float Hardness => 22.5f;
        public float ExplosionResistance => 600f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 316;
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
                Id = 5457,
                Properties = new byte[] { 0,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5458,
                Properties = new byte[] { 0,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5459,
                Properties = new byte[] { 1,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5460,
                Properties = new byte[] { 1,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5461,
                Properties = new byte[] { 2,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5462,
                Properties = new byte[] { 2,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5463,
                Properties = new byte[] { 3,0 },
                CollisionShape = 115,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 5464,
                Properties = new byte[] { 3,1 },
                CollisionShape = 115,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
