using Newtonsoft.Json;

namespace Inventory.Items
{
    [RPGItem("healing_amulet")]
    public class Amulet : GlisteringMelonSlice, IUsable
    {
        [JsonIgnore]
        int power => 10 + 5 * (int)rarity + 2 * (int)quality;
        public override string[] Lore => new string[]
        {
            $"Type: Amulet",
            $"Heal Power: {power}"
        };
        public Amulet()
        {
            Name = "healing amulet";
        }
        public void Use(Player player)
        {
            player.Health += power;
            Particle.Spawn(player.world, Particles.happy_villager, player.Position + v3f.up, v3f.one, 0, 10);
            player.EchoIntoChatFromServer($"&c+{power} ♥");
        }
    }
    
}