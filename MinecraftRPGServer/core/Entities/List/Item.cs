namespace Entities
{
    public class Item : EntityProtocol
    {
        public const int ViewDistance = 32;
        public const int ViewDistanceSqr = ViewDistance * ViewDistance;
        public override string ID => "minecraf:item";
        public override v2f BoxCollider => new v2f(.25f, .25f);
        public override int EntityType => 41;
        public override EntityMetadata meta { get; set; } = new ItemMetadata();

        public override bool RotationSynchronization => false;
        public override bool HeadRotationSynchronization => false;
        public override bool TeleportSynchronization => true;
        public override bool PositionSynchronization => true;

        public Item(World world) : base(world) { }
        public Item(World world, Slot item) : base(world) 
        { 
            (meta as ItemMetadata)["Item"] = item;
        }
        public override void Tick()
        {
            Velocity *= 0.98f;
            Velocity.y -= 0.04f;
            Collision.EntityPhysics.CalcCollisions(this);
        }
        public static void Spawn(World world, Slot item, v3f position, v3f velosity)
        {
            var eitem = new Item(world, item)
            {
                Position = position,
                Velocity = velosity
            };
            foreach (var player in Player.GetInWorldWithSqrDistance(world, position, ViewDistanceSqr))
                player.entitiesController.LoadEntity(eitem);
        }
    }
}