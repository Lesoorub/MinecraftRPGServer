using MineServer;

public class LivingEntityMetadata : EntityMetadata
{
    public enum LivingEntityStatus : byte
    {
        IsHandActive = 0x01,
        /// <summary>
        /// Active hand (0 = main hand, 1 = offhand)
        /// </summary>
        ActiveHand = 0x02,
        IsInRiptideSpinAttack = 0x04
    }
    [Index(8)] public LivingEntityStatus livingEntityStatus = 0;
    [Index(9)] public float Health = 1;
    [Index(10)] public VarInt PotionEffectColor = 0;
    [Index(11)] public bool IsPotionEffectAmbient;
    [Index(12)] public VarInt NumberOfArrowsInEntity;
    [Index(13)] public VarInt NubmerOfBeeStingersInEntity;
    [Index(14)] public Position? BedLocation;
}