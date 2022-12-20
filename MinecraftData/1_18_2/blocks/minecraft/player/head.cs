using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.player_head)]
    public class player_head : IBlockData
    {
        public short DefaultStateID => 6756;
        public state DefaultState => States[0];
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => false;
        public byte SoundGroup => 4;
        public short DroppedItem => 955;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "rotation", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 6756,
                Properties = new byte[] { 0 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6757,
                Properties = new byte[] { 1 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6758,
                Properties = new byte[] { 2 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6759,
                Properties = new byte[] { 3 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6760,
                Properties = new byte[] { 4 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6761,
                Properties = new byte[] { 5 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6762,
                Properties = new byte[] { 6 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6763,
                Properties = new byte[] { 7 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6764,
                Properties = new byte[] { 8 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6765,
                Properties = new byte[] { 9 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6766,
                Properties = new byte[] { 10 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6767,
                Properties = new byte[] { 11 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6768,
                Properties = new byte[] { 12 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6769,
                Properties = new byte[] { 13 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6770,
                Properties = new byte[] { 14 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 6771,
                Properties = new byte[] { 15 },
                CollisionShape = 584,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
