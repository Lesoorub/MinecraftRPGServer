using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.spruce_fence_gate)]
    public class spruce_fence_gate : IBlockData
    {
        public short DefaultStateID => 8675;
        public float Hardness => 2f;
        public float ExplosionResistance => 3f;
        public bool IsTransparent => false;
        public byte SoundGroup => 0;
        public short DroppedItem => 650;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "in_wall", new List<string>() { "True", "False" } },
            { "open", new List<string>() { "True", "False" } },
            { "powered", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 8668,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8669,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8670,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8671,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8672,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8673,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8674,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8675,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8676,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8677,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8678,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8679,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8680,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8681,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8682,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8683,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 263,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8684,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8685,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8686,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8687,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8688,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8689,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8690,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8691,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8692,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8693,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8694,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8695,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8696,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8697,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = null,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8698,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 8699,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 269,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
