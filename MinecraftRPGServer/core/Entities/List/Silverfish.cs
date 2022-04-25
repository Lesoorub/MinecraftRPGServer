namespace Entities
{
    [Entity("silverfish")]
    public class Silverfish : LivingEntityProtocol
    {
        public override string ID => "minecraft:silverfish";
        public override v2f BoxCollider => new v2f(0.4f, 0.3f);
        public override int EntityType => 77;
        public override EntityMetadata meta { get; set; } = new SilverfishMetadata();
        public Silverfish(World world) : base(world) { }
    }
}