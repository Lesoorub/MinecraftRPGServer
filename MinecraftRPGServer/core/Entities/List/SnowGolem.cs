namespace Entities
{
    [Entity("snow_golem")]
    public class SnowGolem : LivingEntityProtocol
    {
        public override string ID => "minecraft:snow_golem";
        public override v2f BoxCollider => new v2f(0.7f, 1.9f);
        public override int EntityType => 82;
        public override EntityMetadata meta { get; set; } = new SnowGolemMetadata();
        public SnowGolem(World world) : base(world) { }
    }
}