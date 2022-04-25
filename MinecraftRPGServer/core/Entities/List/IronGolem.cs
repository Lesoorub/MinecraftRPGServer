namespace Entities
{
    [Entity("iron_golem")]
    public class IronGolem : LivingEntityProtocol
    {
        public override string ID => "minecraft:iron_golem";
        public override v2f BoxCollider => new v2f(1.4f, 2.7f);
        public override int EntityType => 40;
        public override EntityMetadata meta { get; set; } = new IronGolemMetadata();
        public IronGolem(World world) : base(world) { }
    }
}