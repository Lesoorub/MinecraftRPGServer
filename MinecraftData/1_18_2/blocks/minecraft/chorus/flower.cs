using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.chorus_flower)]
    public class chorus_flower : IBlockData
    {
        public short DefaultStateID => 9378;
        public state DefaultState => States[0];
        public float Hardness => 0.4f;
        public float ExplosionResistance => 0.4f;
        public bool IsTransparent => true;
        public byte SoundGroup => 0;
        public short DroppedItem => 239;
        public MinecraftMaterial Material => MinecraftMaterial.plant;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "age", new List<string>() { "0", "1", "2", "3", "4", "5" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9378,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9379,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9380,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9381,
                Properties = new byte[] { 3 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9382,
                Properties = new byte[] { 4 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9383,
                Properties = new byte[] { 5 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
