using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.campfire)]
    public class campfire : IBlockData
    {
        public short DefaultStateID => 15147;
        public state DefaultState => States[3];
        public float Hardness => 2f;
        public float ExplosionResistance => 2f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 1056;
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
                Id = 15144,
                Properties = new byte[] { 0,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15145,
                Properties = new byte[] { 0,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15146,
                Properties = new byte[] { 0,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15147,
                Properties = new byte[] { 0,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15148,
                Properties = new byte[] { 0,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15149,
                Properties = new byte[] { 0,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15150,
                Properties = new byte[] { 0,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15151,
                Properties = new byte[] { 0,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15152,
                Properties = new byte[] { 1,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15153,
                Properties = new byte[] { 1,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15154,
                Properties = new byte[] { 1,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15155,
                Properties = new byte[] { 1,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15156,
                Properties = new byte[] { 1,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15157,
                Properties = new byte[] { 1,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15158,
                Properties = new byte[] { 1,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15159,
                Properties = new byte[] { 1,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15160,
                Properties = new byte[] { 2,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15161,
                Properties = new byte[] { 2,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15162,
                Properties = new byte[] { 2,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15163,
                Properties = new byte[] { 2,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15164,
                Properties = new byte[] { 2,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15165,
                Properties = new byte[] { 2,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15166,
                Properties = new byte[] { 2,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15167,
                Properties = new byte[] { 2,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15168,
                Properties = new byte[] { 3,0,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15169,
                Properties = new byte[] { 3,0,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15170,
                Properties = new byte[] { 3,0,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15171,
                Properties = new byte[] { 3,0,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15172,
                Properties = new byte[] { 3,1,0,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15173,
                Properties = new byte[] { 3,1,0,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15174,
                Properties = new byte[] { 3,1,1,0 },
                CollisionShape = 582,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15175,
                Properties = new byte[] { 3,1,1,1 },
                CollisionShape = 582,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
