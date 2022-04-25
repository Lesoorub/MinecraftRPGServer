using MineServer;

public class AbstractVillagerMetadata : AgeableMobMetadata
{
    [Index(17)] public VarInt HeadShakeTimer = 0;
}
