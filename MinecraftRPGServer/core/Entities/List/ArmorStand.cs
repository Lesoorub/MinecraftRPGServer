namespace Entities
{
    public class ArmorStand : LivingEntityProtocol
    {
        public override string ID => "minecraft:armor_stand";
        public override v2f BoxCollider => new v2f(isSmall ? 0.25f : 0.5f, isSmall ? 0.9875f : 1.975f);
        public override int EntityType => 1;
        public override EntityMetadata meta { get; set; } = new ArmorStandMetadata();
        public bool isSmall => (meta as ArmorStandMetadata).armorStandStatus.HasFlag(ArmorStandMetadata.ArmorStandStatus.isSmall);
        public ArmorStand(World world) : base(world) { }
    }

}