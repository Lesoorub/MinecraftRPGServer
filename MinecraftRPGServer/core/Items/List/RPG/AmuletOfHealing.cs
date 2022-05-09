using Newtonsoft.Json;
using System.Collections.Generic;

namespace Inventory.Items
{
    [RPGItem("amulet_of_healing")]
    public class AmuletOfHealing : GlisteringMelonSlice, IUsable
    {
        [JsonIgnore]
        int power => 10 + 5 * (int)rarity + 2 * (int)quality;
        [JsonIgnore]
        int ReloadTime = 5;
        [JsonIgnore]
        int ReloadTicks => ReloadTime * 20;
        public override string Type => "Amulet";
        public AmuletOfHealing()
        {
            Name = "amulet of healing";
        }
        protected override void GetTooltip(ref List<Parameter> list)
        {
            base.GetTooltip(ref list);
            list.Add(new Parameter("Heal Power", $"{power}"));
            list.Add(new Parameter("Cooldown", $"{ReloadTime} Seconds"));
        }
        public void Use(Player player)
        {
            if (SetCooldown(player, ReloadTicks))
            {
                player.Health += power;
                Particle.Spawn(player.world, Particles.happy_villager, player.Position + v3f.up, v3f.one, 0, 10);
                player.EchoIntoChatFromServer($"&c+{power} ♥");
            }
        }
    }
}