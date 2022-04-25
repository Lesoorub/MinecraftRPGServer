public class VillagerMetadata : AbstractVillagerMetadata
{
    [Index(18)] public VillagerData VillagerData = new VillagerData(VillagerData.Type.plains, VillagerData.Profession.none, 1);
}
