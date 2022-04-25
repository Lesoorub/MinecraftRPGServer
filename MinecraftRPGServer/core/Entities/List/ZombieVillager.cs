namespace Entities
{
    [Entity("zombie_villager")]
    public class ZombieVillager : LivingEntityProtocol
    {
        public override string ID => "minecraft:zombie_villager";
        public override v2f BoxCollider => new v2f(0.6f, 1.95f);
        public override int EntityType => 109;
        public override EntityMetadata meta { get; set; } = new ZombieVillagerMetadata();
        public ZombieVillager(World world) : base(world) { }
    }
}