using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Inventory.Items
{
    public abstract class RPGItem : Item
    {
        public Rarity rarity = Rarity.Legendary;
        public Quality quality = Quality.Excelant;
        readonly string[] rarityNames = Enum.GetNames(typeof(Rarity));
        readonly string[] qualirty_prefix = Enum.GetNames(typeof(Quality));
        readonly char[] rarity_color = new char[]
        {
            Chat.ColorIndexes.gray,
            Chat.ColorIndexes.dark_green,
            Chat.ColorIndexes.aqua,
            Chat.ColorIndexes.dark_red,
            Chat.ColorIndexes.gold,
            Chat.ColorIndexes.light_purple,
        };
        [JsonIgnore]
        public virtual string Type { get; } = "Item";
        public override bool sendNBT => true;
        public override string Name { get => GetPrefix() + base.Name; set => base.Name = value; }
        [JsonIgnore]
        public override string[] Lore
        {
            get
            {
                var l = new List<Parameter>();
                l.Add(new Parameter("Type", Type));
                GetTooltip(ref l);
                l.Add(new Parameter("Rarity", rarityNames[(int)rarity]));
                return l.Select(x => x.ToString()).ToArray();
            }
        }

        public RPGItem(ItemID itemID)
        {
            ItemID = itemID;
        }

        public string GetPrefix()
        {
            return $"&{rarity_color[(int)rarity]}{qualirty_prefix[(int)quality]} ";
        }
        protected virtual void GetTooltip(ref List<Parameter> list) { }
        public void Init(Player player)
        {

        }
        public void BeginItemTick(Player player)
        {
            player.OnItemTick += OnTick;
        }

        public void EndItemTick(Player player)
        {
            player.OnItemTick -= OnTick;
        }

        private void OnTick(Player player)
        {
            if (player == null)
            {
                player.OnItemTick -= OnTick;
                PlayerLogout();
                return;
            }
            Tick(player);
        }

        protected virtual void Tick(Player player) { }
        protected virtual void PlayerLogout() { }

        public bool SetCooldown(Player player, int ticks)
        {
            var now = player.rpgserver.currentTick;
            if (player.Cooldowns.TryGetValue(ItemID, out var cooldown) && cooldown > now) 
                return false;
            player.Cooldowns[ItemID] = now + ticks;
            player.SendCooldown(ItemID, ticks);
            return true;
        }

        public static Dictionary<string, Type> rpgItems = new Dictionary<string, Type>();
        public static void Init()
        {
            foreach (var item_type in RPGServer.GetTypesWithAttribute<RPGItemAttribute>())
            {
                var attr = item_type.GetCustomAttribute<RPGItemAttribute>();
                rpgItems.Add(attr.name, item_type);
            }
        }
        public static bool Has(string nameid) => rpgItems.ContainsKey(nameid);
        public static RPGItem Create(string nameid, Rarity rarity = Rarity.Trash, Quality quality = Quality.Normal)
        {
            if (!Has(nameid)) return null;
            var item = (RPGItem)Activator.CreateInstance(rpgItems[nameid]);
            item.ItemCount = 1;
            item.rarity = rarity;
            item.quality = quality;
            return item;
        }

        public struct Parameter
        {
            public string Name;
            public string Value;

            public Parameter(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString() => $"{Name}: {Value}";
        }
    }
}