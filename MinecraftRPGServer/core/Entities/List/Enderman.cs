namespace Entities
{
    [Entity("enderman")]
    public class Enderman : LivingEntityProtocol
    {
        public override string ID => "minecraft:enderman";
        public override v2f BoxCollider => new v2f(0.6f, 2.9f);
        public override int EntityType => 21;
        public override EntityMetadata meta { get; set; } = new EndermanMetadata();
        public Enderman(World world) : base(world) { }
    }
}