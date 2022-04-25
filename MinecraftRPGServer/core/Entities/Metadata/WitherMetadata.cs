using MineServer;

public class WitherMetadata : MonsterMetadata 
{
    [Index(16)] public VarInt CenterHeadTarget = 0;
    [Index(17)] public VarInt LeftHeadTarget = 0;
    [Index(18)] public VarInt RightHeadTarget = 0;
    [Index(19)] public VarInt InvulnerableTime = 0;
}