namespace Entities
{
    [Entity("husk")]
    public class Husk : LivingEntityProtocol
    {
        public override string ID => "minecraft:husk";
        public override v2f BoxCollider => new v2f(0.6f, 1.95f);
        public override int EntityType => 38;
        public override EntityMetadata meta { get; set; } = new ZombieMetadata();
        public Husk(World world) : base(world) { }
    }
}