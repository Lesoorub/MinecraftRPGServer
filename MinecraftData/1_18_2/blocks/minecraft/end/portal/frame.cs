using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.end_portal_frame)]
    public class end_portal_frame : IBlockData
    {
        public short DefaultStateID => 5355;
        public float Hardness => -1f;
        public float ExplosionResistance => 3600000f;
        public bool IsTransparent => false;
        public byte SoundGroup => 6;
        public short DroppedItem => 311;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "eye", new List<string>() { "True", "False" } },
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 5351,
                Properties = new byte[] { 0,0 },
                CollisionShape = 372,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5352,
                Properties = new byte[] { 0,1 },
                CollisionShape = 372,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5353,
                Properties = new byte[] { 0,2 },
                CollisionShape = 372,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5354,
                Properties = new byte[] { 0,3 },
                CollisionShape = 372,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5355,
                Properties = new byte[] { 1,0 },
                CollisionShape = 373,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5356,
                Properties = new byte[] { 1,1 },
                CollisionShape = 373,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5357,
                Properties = new byte[] { 1,2 },
                CollisionShape = 373,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 5358,
                Properties = new byte[] { 1,3 },
                CollisionShape = 373,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
