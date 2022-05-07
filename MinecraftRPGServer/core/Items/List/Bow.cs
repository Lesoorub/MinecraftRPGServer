using Newtonsoft.Json;
using Packets.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Items
{
    [Item("minecraft:bow")]
    public partial class Bow : RPGItem, IUsable, IUsingFinish
    {
        [JsonIgnore]
        public long startTicks;
        [JsonIgnore]
        public const long minChargeTicks = 2;
        [JsonIgnore]
        public const long maxChargeTicks = 20;
        [JsonIgnore]
        public const int ArrayLifetimeMs = 5000;

        public float ArrowSpeed = 3;
        public float ArrowDamage = 15;


        public Bow()
        {
            Name = "&6Bow";
            Lore = new string[]
            {
                "&aLore1",
                "&fLore2",
            };
            Damage = 50;
        }
        public void Use(Player player)
        {
            startTicks = player.rpgserver.currentTick;
        }

        public void UsingFinish(Player player)
        {
            long deltaTicks = player.rpgserver.currentTick - startTicks;
            if (deltaTicks < minChargeTicks) return;

            var arrowItem = player.inventory.FindItem("minecraft:arrow");
            if (arrowItem == null) return;
            arrowItem.ItemCount--;
            player.SendInventory();

            float charge = Math.Min(deltaTicks, maxChargeTicks) / (float)maxChargeTicks * ArrowSpeed;
            
            ShotArrow(player, player.ForwardDir, charge);
            if (player.IsSneaking)
            {
                float angle = 15;
                ShotArrow(player, (player.ForwardDir + v3f.FromRotationInvertX(player.Rotation + new v2f(angle, 0))).Normalized, charge);
                ShotArrow(player, (player.ForwardDir + v3f.FromRotationInvertX(player.Rotation + new v2f(-angle, 0))).Normalized, charge);
            }
        }

        void ShotArrow(Player player, v3f direction, float speed)
        {
            var entity = new Entities.Arrow(player.world)
            {
                Position = player.EyePosition + player.ForwardDir * 2,
                Velocity = direction * speed,
                SenderBow = this,
                sender = player
            };
            entity.ForceLoadSelfAnyPlayersInRadius(player.rpgserver.config.MaxDrawEntitiesRange);
            entity.SendVelosity(player.network);
        }
    }
    public class RPGItem : Item
    {
        public Rarity rarity = Rarity.Legendary;
        public Quality quality = Quality.Excelant;
        public override bool sendNBT => true;

        readonly string[] qualirty_prefix = new string[] { "Poor", "Normal", "Good", "Excelant", "Perfect" };
        readonly string[] rarity_prefix = new string[] { "common", "uncommon", "rare", "mystic", "legendary" };
        readonly char[] rarity_color = new char[]
        {
                Chat.ColorIndexes.white,
                Chat.ColorIndexes.green,
                Chat.ColorIndexes.dark_red,
                Chat.ColorIndexes.light_purple,
                Chat.ColorIndexes.yellow,
        };
        public string GetPrefix()
        {
            return $"&{rarity_color[(int)rarity]}{qualirty_prefix[(int)quality]} {rarity_prefix[(int)rarity]}";
        }
    }
}