using System.Linq;

namespace Entities
{
    [Entity("zombie")]
    public class Zombie : LivingEntityProtocol
    {
        public override string ID => "minecraft:zombie";
        public override v2f BoxCollider => new v2f(0.6f, 1.95f);
        public override int EntityType => 107;
        public override EntityMetadata meta { get; set; } = new ZombieMetadata();
        public override Sound HurtSound => new Sound(SoundID.entity_zombie_hurt, Categories.PLAYERS);
        public Zombie(World world) : base(world) 
        {
            Health = MaxHealth = 40;

            OnTick += Zombie_OnTick;
        }

        private void Zombie_OnTick(Entity entity, long tick)
        {
            int tickmod = 10;
            if (tick % tickmod != 0) return;//Every 10 ticks (0.5 seconds)
            int maxDistance = 32;
            var player = world.entities.GetEntitiesInCircle(position, maxDistance)
                .Where(x => x.ID.Equals(Player.NameID)).FirstOrDefault() as Player;
            if (player == null) return;


            if ((player.Position.x - Position.x) + 
                (player.Position.y - Position.y) + 
                (player.Position.z - Position.z) > maxDistance) return;
            var pf = new SimplePathfinding(player.world, maxDistance, BoxCollider, false, player);
            if (pf.TryGetPath(Position, player.Position, out var path))
            {
                int index = 0;
                foreach (var p in path)
                {
                    Hologram.Create(player, (v3f)p + v3f.one / 2, $"&4{index++}", tickmod);
                }
            }
            else
            {
                System.Console.WriteLine("Path not found");
            }
        }
    }
}