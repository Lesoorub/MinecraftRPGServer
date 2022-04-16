public class ModEntityData : LivingEntityMetadata
{
    public enum MobStatus : byte
    {
        NoAI = 0x01,
        IsLeftHanded = 0x02,
        IsAggressive = 0x04
    }
    [Index(15)] public MobStatus modStatus = 0;
}