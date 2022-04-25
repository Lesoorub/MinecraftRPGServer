namespace Entities
{
    [Entity("spider")]
    public class Spider : LivingEntityProtocol
    {
        public override string ID => "minecraft:spider";
        public override v2f BoxCollider => new v2f(1.4f, 0.9f);
        public override int EntityType => 85;
        public override EntityMetadata meta { get; set; } = new SpiderMetadata();
        public Spider(World world) : base(world) { }
    }
}