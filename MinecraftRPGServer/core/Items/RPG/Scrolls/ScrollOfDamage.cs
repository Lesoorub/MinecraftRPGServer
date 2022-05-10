namespace Scrolls
{
    public class ScrollOfDamage : Scroll
    {
        public float Radius = 3;
        public float BaseDamage = 1;

        public override string Description => $"Damage all enemies within radius of {Radius} blocks.";
        public ScrollOfDamage(float radius, float baseDamage)
        {
            Radius = radius;
            BaseDamage = baseDamage;
        }

        public override void Execute(Player player, float Power)
        {
            Particle.SpawnHorizontalCircle(
                player.world,
                Particles.soul,
                player.Position + v3f.up * 0.1f,
                v3f.zero,
                0,
                1,
                Radius,
                36);
            foreach (var entity in player.world.entities.GetEntitiesInCircle(player.Position, Radius))
            {
                if (entity is LivingEntity living &&
                    entity.EntityID != player.EntityID &&
                    living.Health > 0)
                {
                    player.ApplyDamageToTarget(living, BaseDamage);
                }
            }
        }
    }
}