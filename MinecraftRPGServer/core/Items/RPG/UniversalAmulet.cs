using Newtonsoft.Json;
using System.Collections.Generic;

namespace Inventory.Items
{
    [RPGItem("amulet")]
    public class UniversalAmulet : Amulet, IUsable
    {
        [JsonIgnore]
        float power => 1 + .25f * (int)rarity + .1f * (int)quality;
        [JsonIgnore]
        int ReloadTime = 1;
        [JsonIgnore]
        int ReloadTicks => ReloadTime * RPGServer.TicksPerSecond;
        public UniversalAmulet()
        {
            Name = "Universal amulet";
        }
        protected override void GetTooltip(ref List<Parameter> list)
        {
            base.GetTooltip(ref list);
            list.Add(new Parameter("Power", $"{power * 100:N0}%"));
            list.Add(new Parameter("Cooldown", $"{ReloadTime} Seconds"));
            list.Add(new Parameter("- " + (Scroll != null ? Scroll.Name : "none")));
        }
        public void Use(Player player)
        {
            if (player.IsSneaking)
            {
                //Open interface
                OpenWindow(player);
                return;
            }
            if (Scroll == null) return;
            if (SetCooldown(player, ReloadTicks))
                Scroll.Execute(player, player.Position, power);
            else
                player.EchoIntoChatFromServer($"Reloading {(player.Cooldowns[ItemID] - player.rpgserver.currentTick) / RPGServer.TicksPerSecond} second(s)");
        }
    }
}