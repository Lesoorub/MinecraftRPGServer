using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.scaffolding)]
    public class scaffolding : IBlockData
    {
        public short DefaultStateID => 15036;
        public state DefaultState => States[31];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 19;
        public short DroppedItem => 584;
        public MinecraftMaterial Material => MinecraftMaterial.decoration;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "bottom", new List<string>() { "True", "False" } },
            { "distance", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 15005,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15006,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15007,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15008,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15009,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15010,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15011,
                Properties = new byte[] { 0,3,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15012,
                Properties = new byte[] { 0,3,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15013,
                Properties = new byte[] { 0,4,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15014,
                Properties = new byte[] { 0,4,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15015,
                Properties = new byte[] { 0,5,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15016,
                Properties = new byte[] { 0,5,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15017,
                Properties = new byte[] { 0,6,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15018,
                Properties = new byte[] { 0,6,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15019,
                Properties = new byte[] { 0,7,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15020,
                Properties = new byte[] { 0,7,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15021,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15022,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15023,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15024,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15025,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15026,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15027,
                Properties = new byte[] { 1,3,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15028,
                Properties = new byte[] { 1,3,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15029,
                Properties = new byte[] { 1,4,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15030,
                Properties = new byte[] { 1,4,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15031,
                Properties = new byte[] { 1,5,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15032,
                Properties = new byte[] { 1,5,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15033,
                Properties = new byte[] { 1,6,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15034,
                Properties = new byte[] { 1,6,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15035,
                Properties = new byte[] { 1,7,0 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 15036,
                Properties = new byte[] { 1,7,1 },
                CollisionShape = 686,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
