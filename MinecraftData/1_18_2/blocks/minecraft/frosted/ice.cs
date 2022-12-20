using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.frosted_ice)]
    public class frosted_ice : IBlockData
    {
        public short DefaultStateID => 9499;
        public state DefaultState => States[0];
        public float Hardness => 0.5f;
        public float ExplosionResistance => 0.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 6;
        public short DroppedItem => 0;
        public MinecraftMaterial Material => MinecraftMaterial.ice;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "age", new List<string>() { "0", "1", "2", "3" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 9499,
                Properties = new byte[] { 0 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9500,
                Properties = new byte[] { 1 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9501,
                Properties = new byte[] { 2 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 9502,
                Properties = new byte[] { 3 },
                CollisionShape = 0,
                LightCost = 1,
                HasSideTransparency = false,
            }
        };
    }
}
