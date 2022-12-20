using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.grindstone)]
    public class grindstone : IBlockData
    {
        public short DefaultStateID => 15075;
        public state DefaultState => States[4];
        public float Hardness => 2f;
        public float ExplosionResistance => 6f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 1048;
        public MinecraftMaterial Material => MinecraftMaterial.repair_station;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "face", new List<string>() { "floor", "wall", "ceiling" } },
            { "facing", new List<string>() { "north", "south", "west", "east" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15071,
                Properties = new byte[] { 0,0 },
                CollisionShape = 688,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15072,
                Properties = new byte[] { 0,1 },
                CollisionShape = 688,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15073,
                Properties = new byte[] { 0,2 },
                CollisionShape = 691,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15074,
                Properties = new byte[] { 0,3 },
                CollisionShape = 691,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15075,
                Properties = new byte[] { 1,0 },
                CollisionShape = 694,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15076,
                Properties = new byte[] { 1,1 },
                CollisionShape = 697,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15077,
                Properties = new byte[] { 1,2 },
                CollisionShape = 698,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15078,
                Properties = new byte[] { 1,3 },
                CollisionShape = 701,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15079,
                Properties = new byte[] { 2,0 },
                CollisionShape = 702,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15080,
                Properties = new byte[] { 2,1 },
                CollisionShape = 702,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15081,
                Properties = new byte[] { 2,2 },
                CollisionShape = 703,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15082,
                Properties = new byte[] { 2,3 },
                CollisionShape = 703,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
