using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.soul_campfire)]
    public class soul_campfire : IBlockData
    {
        public short DefaultStateID => 15179;
        public state DefaultState => States[3];
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 1057;
        public MinecraftMaterial Material => MinecraftMaterial.wood;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "south", "west", "east" } },
            { "lit", new List<string>() { "True", "False" } },
            { "signal_fire", new List<string>() { "True", "False" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15176,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15177,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15178,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15179,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15180,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15181,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15182,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15183,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15184,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15185,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15186,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15187,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15188,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15189,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15190,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15191,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15192,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15193,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15194,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15195,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15196,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15197,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15198,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15199,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15200,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15201,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15202,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15203,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15204,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15205,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15206,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15207,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
