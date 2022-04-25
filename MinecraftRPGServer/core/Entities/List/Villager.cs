namespace Entities
{
    [Entity("villager")]
    public class Villager : LivingEntityProtocol
    {
        public override string ID => "minecraft:villager";
        public override v2f BoxCollider => new v2f(0.6f, 1.95f);
        public override int EntityType => 98;
        public override EntityMetadata meta { get; set; } = new VillagerMetadata();
        public Villager(World world) : base(world) { }
    }
}