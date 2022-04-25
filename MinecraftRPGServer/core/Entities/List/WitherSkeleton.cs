namespace Entities
{
    [Entity("wither_skeleton")]
    public class WitherSkeleton : LivingEntityProtocol
    {
        public override string ID => "minecraft:wither_skeleton";
        public override v2f BoxCollider => new v2f(0.7f, 2.4f);
        public override int EntityType => 103;
        public override EntityMetadata meta { get; set; } = new WitherSkeletonMetadata();
        public WitherSkeleton(World world) : base(world) { }
    }
}