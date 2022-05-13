using System.Text.Json.Serialization;

namespace Inventory.Items
{
    [RPGItem("scroll_of_area_damage")]
    public class ScrollOfAreaDamage : Scroll
    {
        [JsonIgnore]
        public float Radius = 3;
        [JsonIgnore]
        public float BaseDamage = 1;

        [JsonIgnore]
        public override string Description => $"Deal {BaseDamage} damage within radius of {Radius} blocks.";

        public ScrollOfAreaDamage()
        {
            Name = "Scroll of area damage";
        }

        public override void Execute(Player player, v3f position, float Power)
        {
            Particle.SpawnHorizontalCircle(
                player.world,
                Particles.soul,
                position + v3f.up * 0.1f,
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