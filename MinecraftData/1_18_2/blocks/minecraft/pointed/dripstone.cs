using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.pointed_dripstone)]
    public class pointed_dripstone : IBlockData
    {
        public short DefaultStateID => 18549;
        public state DefaultState => States[5];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => true;
        public byte SoundGroup => 57;
        public short DroppedItem => 1100;
        public MinecraftMaterial Material => MinecraftMaterial.stone;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "thickness", new List<string>() { "tip_merge", "tip", "frustum", "middle", "base" } },
            { "vertical_direction", new List<string>() { "up", "down" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 18544,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 685,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18545,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 685,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18546,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 685,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18547,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 685,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18548,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 765,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18549,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 765,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18550,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 766,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18551,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 766,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18552,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 212,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18553,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 212,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18554,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 212,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18555,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 212,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18556,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 636,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18557,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 636,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18558,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 636,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18559,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 636,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18560,
                Properties = new byte[] { 4,0,0 },
                CollisionShape = 248,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18561,
                Properties = new byte[] { 4,0,1 },
                CollisionShape = 248,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18562,
                Properties = new byte[] { 4,1,0 },
                CollisionShape = 248,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 18563,
                Properties = new byte[] { 4,1,1 },
                CollisionShape = 248,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
