using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.sea_pickle)]
    public class sea_pickle : IBlockData
    {
        public short DefaultStateID => 9890;
        public state DefaultState => States[0];
        public float Hardness => 0f;
        public float ExplosionResistance => 0f;
        public bool IsTransparent => true;
        public byte SoundGroup => 13;
        public short DroppedItem => 156;
        public MinecraftMaterial Material => MinecraftMaterial.underwater_plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "pickles", new List<string>() { "1", "2", "3", "4" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9890,
                Properties = new byte[] { 0,0 },
                CollisionShape = 680,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9891,
                Properties = new byte[] { 0,1 },
                CollisionShape = 680,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9892,
                Properties = new byte[] { 1,0 },
                CollisionShape = 681,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9893,
                Properties = new byte[] { 1,1 },
                CollisionShape = 681,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9894,
                Properties = new byte[] { 2,0 },
                CollisionShape = 682,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9895,
                Properties = new byte[] { 2,1 },
                CollisionShape = 682,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9896,
                Properties = new byte[] { 3,0 },
                CollisionShape = 683,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9897,
                Properties = new byte[] { 3,1 },
                CollisionShape = 683,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
