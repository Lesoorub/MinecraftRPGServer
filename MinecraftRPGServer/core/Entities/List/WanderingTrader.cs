namespace Entities
{
    [Entity("wandering_trader")]
    public class WanderingTrader : LivingEntityProtocol
    {
        public override string ID => "minecraft:wandering_trader";
        public override v2f BoxCollider => new v2f(0.6f, 1.95f);
        public override int EntityType => 100;
        public override EntityMetadata meta { get; set; } = new WanderingTraderMetadata();
        public WanderingTrader(World world) : base(world) { }
    }
}