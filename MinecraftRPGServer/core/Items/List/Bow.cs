using Newtonsoft.Json;
using Packets.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Items
{
    [Item(ItemID.bow)]
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

        public virtual float ArrowSpeed { get; set; } = 3;
        public virtual float ArrowDamage { get; set; } = 15;
        public override string Type => "Bow";

        public Bow() : base(ItemID.bow) { }

        public virtual void Use(Player player)
        {
            startTicks = player.rpgserver.currentTick;
        }
        public virtual void UsingFinish(Player player)
        {
            long deltaTicks = player.rpgserver.currentTick - startTicks;
            if (deltaTicks < minChargeTicks) return;

            if (!CanShot(player))
                return;

            Shot(player, Math.Min(deltaTicks, maxChargeTicks) / (float)maxChargeTicks);
        }
        protected virtual bool CanShot(Player player)
        {
            var arrowItem = player.inventory.FindItem(ItemID.arrow);
            if (arrowItem == null) return false;
            arrowItem.ItemCount--;
            player.SendInventory();
            return true;
        }
        public virtual void Shot(Player player, float charge)
        {
            ShotArrow(player, player.ForwardDir, charge * ArrowSpeed);
        }
        protected void ShotArrow(Player player, v3f direction, float speed)
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
}