using System;
using System.Collections.Generic;
using System.Reflection;

namespace Inventory.Items
{
    public abstract class RPGItem : Item
    {
        public Rarity rarity = Rarity.Legendary;
        public Quality quality = Quality.Excelant;
        public override bool sendNBT => true;

        public override string Name { get => GetPrefix() + base.Name; set => base.Name = value; }

        readonly string[] qualirty_prefix = new string[] { "Poor", "Normal", "Good", "Excelant", "Perfect" };
        readonly char[] rarity_color = new char[]
        {
            Chat.ColorIndexes.white,
            Chat.ColorIndexes.green,
            Chat.ColorIndexes.dark_red,
            Chat.ColorIndexes.light_purple,
            Chat.ColorIndexes.yellow,
        };

        public RPGItem(ItemID itemID)
        {
            ItemID = itemID;
        }

        public string GetPrefix()
        {
            return $"&{rarity_color[(int)rarity]}{qualirty_prefix[(int)quality]} ";
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
        public static RPGItem Create(string nameid, Rarity rarity = Rarity.Common, Quality quality = Quality.Normal)
        {
            if (!Has(nameid)) return null;
            var item = (RPGItem)Activator.CreateInstance(rpgItems[nameid]);
            item.ItemCount = 1;
            item.rarity = rarity;
            item.quality = quality;
            return item;
        }
    }
}