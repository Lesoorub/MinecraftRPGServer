using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.cyan_banner)]
    public class cyan_banner : IBlockData
    {
        public short DefaultStateID => 8291;
        public float Hardness => 1f;
        public float ExplosionResistance => 1f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 991;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "rotation", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 8291,
                Properties = new byte[] { 0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8292,
                Properties = new byte[] { 1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8293,
                Properties = new byte[] { 2 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8294,
                Properties = new byte[] { 3 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8295,
                Properties = new byte[] { 4 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8296,
                Properties = new byte[] { 5 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8297,
                Properties = new byte[] { 6 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8298,
                Properties = new byte[] { 7 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8299,
                Properties = new byte[] { 8 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8300,
                Properties = new byte[] { 9 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8301,
                Properties = new byte[] { 10 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8302,
                Properties = new byte[] { 11 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8303,
                Properties = new byte[] { 12 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8304,
                Properties = new byte[] { 13 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8305,
                Properties = new byte[] { 14 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8306,
                Properties = new byte[] { 15 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
