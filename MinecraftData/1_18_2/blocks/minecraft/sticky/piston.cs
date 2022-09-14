using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.sticky_piston)]
    public class sticky_piston : IBlockData
    {
        public short DefaultStateID => 1391;
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 591;
        public MinecraftMaterial Material => MinecraftMaterial.piston;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "extended", new List<string>() { "True", "False" } },
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 1385,
                Properties = new byte[] { 0,0 },
                CollisionShape = 8,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1386,
                Properties = new byte[] { 0,1 },
                CollisionShape = 10,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1387,
                Properties = new byte[] { 0,2 },
                CollisionShape = 11,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1388,
                Properties = new byte[] { 0,3 },
                CollisionShape = 12,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1389,
                Properties = new byte[] { 0,4 },
                CollisionShape = 13,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1390,
                Properties = new byte[] { 0,5 },
                CollisionShape = 14,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 1391,
                Properties = new byte[] { 1,0 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1392,
                Properties = new byte[] { 1,1 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1393,
                Properties = new byte[] { 1,2 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1394,
                Properties = new byte[] { 1,3 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1395,
                Properties = new byte[] { 1,4 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 1396,
                Properties = new byte[] { 1,5 },
                CollisionShape = 0,
                LightCost = 15,
                HasSideTransparency = false,
            }
        };
    }
}
