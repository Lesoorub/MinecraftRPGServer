using System;

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

        public int elapsedTicks = 0;
        public const int PickUpDelayInTicks = 40;
        public bool PickUpReady => elapsedTicks >= PickUpDelayInTicks;

        public Item(World world) : base(world) { }
        public Item(World world, Inventory.Item item) : base(world) 
        { 
            (meta as ItemMetadata)["Item"] = item;
            OnTick += Item_OnTick;
        }

        private void Item_OnTick(Entity entity, long tick)
        {
            if (elapsedTicks < PickUpDelayInTicks)
                elapsedTicks++;
        }
        public static void Spawn(World world, Inventory.Item item, v3f position)
        {
            int coly = (int)position.y;
            for (int y = coly; y >= -64; y--)
            {
                if (world.GetBlock((int)Math.Floor(position.x), (short)y, (int)Math.Floor(position.z)).haveCollision)
                {
                    coly = y;
                    break;
                }
            }
            var eitem = new Item(world, item);
            eitem.Position = new v3f(position.x, coly + 1 + eitem.BoxCollider.y / 2, position.z);

            foreach (var player in Player.GetInWorldWithSqrDistance(world, position, ViewDistanceSqr))
                player.entitiesController.LoadEntity(eitem);
        }
    }
}