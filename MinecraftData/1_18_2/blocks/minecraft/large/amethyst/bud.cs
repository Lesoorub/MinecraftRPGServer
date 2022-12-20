using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.large_amethyst_bud)]
    public class large_amethyst_bud : IBlockData
    {
        public short DefaultStateID => 17687;
        public state DefaultState => States[9];
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => true;
        public byte SoundGroup => 52;
        public short DroppedItem => 1098;
        public MinecraftMaterial Material => MinecraftMaterial.amethyst;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "facing", new List<string>() { "north", "east", "south", "west", "up", "down" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17678,
                Properties = new byte[] { 0,0 },
                CollisionShape = 747,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17679,
                Properties = new byte[] { 0,1 },
                CollisionShape = 747,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17680,
                Properties = new byte[] { 1,0 },
                CollisionShape = 748,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17681,
                Properties = new byte[] { 1,1 },
                CollisionShape = 748,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17682,
                Properties = new byte[] { 2,0 },
                CollisionShape = 749,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17683,
                Properties = new byte[] { 2,1 },
                CollisionShape = 749,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17684,
                Properties = new byte[] { 3,0 },
                CollisionShape = 750,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17685,
                Properties = new byte[] { 3,1 },
                CollisionShape = 750,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17686,
                Properties = new byte[] { 4,0 },
                CollisionShape = 751,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17687,
                Properties = new byte[] { 4,1 },
                CollisionShape = 751,
                LightCost = 0,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17688,
                Properties = new byte[] { 5,0 },
                CollisionShape = 752,
                LightCost = 1,
                HasSideTransparency = false,
            },
            new state
            {
                Id = 17689,
                Properties = new byte[] { 5,1 },
                CollisionShape = 752,
                LightCost = 0,
                HasSideTransparency = false,
            }
        };
    }
}
