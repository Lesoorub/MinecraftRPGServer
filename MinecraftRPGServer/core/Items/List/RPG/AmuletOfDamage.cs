using Newtonsoft.Json;
using System.Collections.Generic;

namespace Inventory.Items
{
    [RPGItem("amulet_of_damage")]
    public class AmuletOfDamage : GlisteringMelonSlice, IUsable
    {
        [JsonIgnore]
        int power => 1 + 3 * (int)rarity + 1 * (int)quality;
        [JsonIgnore]
        int ReloadTime = 1;
        [JsonIgnore]
        int ReloadTicks => ReloadTime * RPGServer.TicksPerSecond;
        [JsonIgnore]
        int Radius = 3;
        public override string Type => "Amulet";
        public AmuletOfDamage()
        {
            Name = "amulet of damage";
        }
        protected override void GetTooltip(ref List<Parameter> list)
        {
            base.GetTooltip(ref list);
            list.Add(new Parameter("Damage Power", $"{power}"));
            list.Add(new Parameter("Cooldown", $"{ReloadTime} Seconds"));
            list.Add(new Parameter("Radius", $"{Radius} blocks"));
        }
        public void Use(Player player)
        {
            if (SetCooldown(player, ReloadTicks))
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
                        player.ApplyDamageToTarget(living, power);
                    }
                }
            }
            else
                player.EchoIntoChatFromServer($"Reloading {(player.Cooldowns[ItemID] - player.rpgserver.currentTick) / RPGServer.TicksPerSecond} second(s)");
        }
    }
}