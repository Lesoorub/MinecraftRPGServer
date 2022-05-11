using System.Text.Json.Serialization;

namespace Inventory.Items
{
    [RPGItem("scroll_of_healing")]
    public class ScrollOfHealing : Scroll
    {
        [JsonIgnore]
        int BaseHeal => 10 + 5 * (int)rarity + 2 * (int)quality;
        [JsonIgnore]
        public float Radius = 3;

        public override string Description => $"Heal {BaseHeal} HP of the caster.";

        public ScrollOfHealing()
        {
            Name = "Scroll of healing";
        }
        public override void Execute(Player player, v3f position, float Power)
        {
            player.Health += BaseHeal * Power;
            Particle.Spawn(player.world, Particles.happy_villager, player.Position + v3f.up, v3f.one, 0, 10);
            player.EchoIntoChatFromServer($"&c+{BaseHeal * Power:N1} ♥");
        }
    }
}