public class ArmorStandMetadata : LivingEntityMetadata
{
    public enum ArmorStandStatus : byte
    {
        isSmall = 0x01,
        HasArms = 0x04,
        HasNoBasePlate = 0x08,
        IsMarker = 0x10
    }
    [Index(15)] public ArmorStandStatus armorStandStatus = 0;
    [Index(16)] public v3f HeadRotation = new v3f(0, 0, 0);
    [Index(17)] public v3f BodyRotation = new v3f(0, 0, 0);
    [Index(18)] public v3f LeftArmRotation = new v3f(-10, 0, -10);
    [Index(19)] public v3f RightArmRotation = new v3f(-15, 0, 10);
    [Index(20)] public v3f LeftLegRotation = new v3f(-1, 0, -1);
    [Index(21)] public v3f RightLegRotation = new v3f(1, 0, 1);
}