using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    [Block(BlockNameID.sculk_sensor)]
    public class sculk_sensor : IBlockData
    {
        public short DefaultStateID => 17719;
        public float Hardness => 1.5f;
        public float ExplosionResistance => 1.5f;
        public bool IsTransparent => false;
        public byte SoundGroup => 70;
        public short DroppedItem => 603;
        public MinecraftMaterial Material => MinecraftMaterial.sculk;
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {
            { "power", new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" } },
            { "sculk_sensor_phase", new List<string>() { "inactive", "active", "cooldown" } },
            { "waterlogged", new List<string>() { "True", "False" } }
        };
        public state[] States => new state[]
        {
            new state
            {
                Id = 17718,
                Properties = new byte[] { 0,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17719,
                Properties = new byte[] { 0,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17720,
                Properties = new byte[] { 0,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17721,
                Properties = new byte[] { 0,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17722,
                Properties = new byte[] { 0,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17723,
                Properties = new byte[] { 0,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17724,
                Properties = new byte[] { 1,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17725,
                Properties = new byte[] { 1,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17726,
                Properties = new byte[] { 1,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17727,
                Properties = new byte[] { 1,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17728,
                Properties = new byte[] { 1,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17729,
                Properties = new byte[] { 1,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17730,
                Properties = new byte[] { 2,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17731,
                Properties = new byte[] { 2,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17732,
                Properties = new byte[] { 2,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17733,
                Properties = new byte[] { 2,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17734,
                Properties = new byte[] { 2,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17735,
                Properties = new byte[] { 2,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17736,
                Properties = new byte[] { 3,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17737,
                Properties = new byte[] { 3,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17738,
                Properties = new byte[] { 3,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17739,
                Properties = new byte[] { 3,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17740,
                Properties = new byte[] { 3,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17741,
                Properties = new byte[] { 3,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17742,
                Properties = new byte[] { 4,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17743,
                Properties = new byte[] { 4,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17744,
                Properties = new byte[] { 4,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17745,
                Properties = new byte[] { 4,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17746,
                Properties = new byte[] { 4,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17747,
                Properties = new byte[] { 4,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17748,
                Properties = new byte[] { 5,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17749,
                Properties = new byte[] { 5,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17750,
                Properties = new byte[] { 5,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17751,
                Properties = new byte[] { 5,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17752,
                Properties = new byte[] { 5,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17753,
                Properties = new byte[] { 5,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17754,
                Properties = new byte[] { 6,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17755,
                Properties = new byte[] { 6,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17756,
                Properties = new byte[] { 6,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17757,
                Properties = new byte[] { 6,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17758,
                Properties = new byte[] { 6,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17759,
                Properties = new byte[] { 6,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17760,
                Properties = new byte[] { 7,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17761,
                Properties = new byte[] { 7,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17762,
                Properties = new byte[] { 7,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17763,
                Properties = new byte[] { 7,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17764,
                Properties = new byte[] { 7,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17765,
                Properties = new byte[] { 7,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17766,
                Properties = new byte[] { 8,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17767,
                Properties = new byte[] { 8,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17768,
                Properties = new byte[] { 8,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17769,
                Properties = new byte[] { 8,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17770,
                Properties = new byte[] { 8,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17771,
                Properties = new byte[] { 8,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17772,
                Properties = new byte[] { 9,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17773,
                Properties = new byte[] { 9,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17774,
                Properties = new byte[] { 9,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17775,
                Properties = new byte[] { 9,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17776,
                Properties = new byte[] { 9,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17777,
                Properties = new byte[] { 9,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17778,
                Properties = new byte[] { 10,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17779,
                Properties = new byte[] { 10,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17780,
                Properties = new byte[] { 10,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17781,
                Properties = new byte[] { 10,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17782,
                Properties = new byte[] { 10,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17783,
                Properties = new byte[] { 10,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17784,
                Properties = new byte[] { 11,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17785,
                Properties = new byte[] { 11,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17786,
                Properties = new byte[] { 11,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17787,
                Properties = new byte[] { 11,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17788,
                Properties = new byte[] { 11,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17789,
                Properties = new byte[] { 11,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17790,
                Properties = new byte[] { 12,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17791,
                Properties = new byte[] { 12,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17792,
                Properties = new byte[] { 12,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17793,
                Properties = new byte[] { 12,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17794,
                Properties = new byte[] { 12,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17795,
                Properties = new byte[] { 12,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17796,
                Properties = new byte[] { 13,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17797,
                Properties = new byte[] { 13,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17798,
                Properties = new byte[] { 13,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17799,
                Properties = new byte[] { 13,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17800,
                Properties = new byte[] { 13,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17801,
                Properties = new byte[] { 13,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17802,
                Properties = new byte[] { 14,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17803,
                Properties = new byte[] { 14,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17804,
                Properties = new byte[] { 14,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17805,
                Properties = new byte[] { 14,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17806,
                Properties = new byte[] { 14,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17807,
                Properties = new byte[] { 14,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17808,
                Properties = new byte[] { 15,0,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17809,
                Properties = new byte[] { 15,0,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17810,
                Properties = new byte[] { 15,1,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17811,
                Properties = new byte[] { 15,1,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17812,
                Properties = new byte[] { 15,2,0 },
                CollisionShape = 7,
                LightCost = 1,
                HasSideTransparency = true,
            },
            new state
            {
                Id = 17813,
                Properties = new byte[] { 15,2,1 },
                CollisionShape = 7,
                LightCost = 0,
                HasSideTransparency = true,
            }
        };
    }
}
