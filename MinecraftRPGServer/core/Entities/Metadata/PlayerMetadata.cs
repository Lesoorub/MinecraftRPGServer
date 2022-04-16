using MineServer;

public class PlayerMetadata : LivingEntityMetadata
{
    public enum PlayerStatus : byte
    {
        CapeEnabled = 0x01,
        JacketEnabled = 0x02,
        LeftSleeveEnabled = 0x04,
        RightSleeveEnabled = 0x08,
        LeftPantsLegEnabled = 0x10,
        RightPantsLegEnabled = 0x20,
        HatEnabled = 0x40
    }
    [Index(15)] public float AdditionalHearts = 0;
    [Index(16)] public VarInt Score = 0;
    [Index(17)] public PlayerStatus playerStatus = 0;
    [Index(18)] public byte MainHand = 1;
    [Index(19)] public NBTTag LeftShoulderEntityData;
    [Index(20)] public NBTTag RightShoulderEntityData;
}