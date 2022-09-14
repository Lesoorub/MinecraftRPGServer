using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.polished_blackstone_button)]
    public class polished_blackstone_button : IBlockData
    {
        public short DefaultStateID => 17016;
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 4;
        public short DroppedItem => 610;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "face", new List<string>() { "floor", "wall", "ceiling" } },
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17007,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17008,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17009,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17010,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17011,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17012,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17013,
                Properties = new byte[] { 0,3,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17014,
                Properties = new byte[] { 0,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17015,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17016,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17017,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17018,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17019,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17020,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17021,
                Properties = new byte[] { 1,3,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17022,
                Properties = new byte[] { 1,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17023,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17024,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17025,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17026,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17027,
                Properties = new byte[] { 2,2,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17028,
                Properties = new byte[] { 2,2,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17029,
                Properties = new byte[] { 2,3,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17030,
                Properties = new byte[] { 2,3,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
