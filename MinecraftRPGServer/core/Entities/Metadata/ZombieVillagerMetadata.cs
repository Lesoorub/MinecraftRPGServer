public class ZombieVillagerMetadata : ZombieMetadata
{
    [Index(19)] public bool IsConverting = false;
    [Index(20)] public VillagerData VillagerData = new VillagerData(VillagerData.Type.plains, VillagerData.Profession.none, 1);
}
