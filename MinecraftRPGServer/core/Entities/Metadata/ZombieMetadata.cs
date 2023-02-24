using MineServer;

public class ZombieMetadata : MonsterMetadata
{
    [Index(16)] public bool isBaby = false;
    [Index(17)] public VarInt Unused = 0;
    [Index(18)] public bool isBecomingaDrowned = false;
}
public class HuskMetadata : ZombieMetadata { }
public class ZombifiedPiglinMetadata : ZombieMetadata { }
public class EndermanMetadata : MonsterMetadata
{
    [Index(16)] public OptBlockID CarriedBlock = OptBlockID.Absent;
    [Index(17)] public bool isScreaming = false;
    [Index(18)] public bool isStaring = false;
}