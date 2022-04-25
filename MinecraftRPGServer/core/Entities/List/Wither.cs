namespace Entities
{
    [Entity("wither")]
    public class Wither : LivingEntityProtocol
    {
        public override string ID => "minecraft:wither";
        public override v2f BoxCollider => new v2f(0.9f, 3.5f);
        public override int EntityType => 102;
        public override EntityMetadata meta { get; set; } = new WitherMetadata();
        public Wither(World world) : base(world) { }
    }
}