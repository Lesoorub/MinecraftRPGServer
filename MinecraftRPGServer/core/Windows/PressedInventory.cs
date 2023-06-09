using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    public class PressedInventory
    {
        public Dictionary<int, Item> Items = new Dictionary<int, Item>();

        public PressedInventory()
        {
        }

        public PressedInventory(InventoryOfPlayer inv)
        {
            var mainInv = inv.mainInv.Select(x => x.item).ToArray();
            var hotbar = inv.hotbar.Select(x => x.item).ToArray();
            var Armor = inv.Armor.Select(x => x.item).ToArray();
            var Craft = inv.Craft.Select(x => x.item).ToArray();
            var Offhand = inv.Offhand.item;
            var CarriedItem = inv.CarriedItem.item;

            int index = 0;
            void Add(params Item[] items)
            {
                foreach (var item in items)
                {
                    if (item != null)
                        Items.Add(index, item);
                    index++;
                }
            }
            Add(Craft);
            Add(Armor);
            Add(mainInv);
            Add(hotbar);
            Add(Offhand);
            Add(CarriedItem);
        }
        public void UnloadTo(ref InventoryOfPlayer inv)
        {
            Item item;
            void fill(ref IndexedItem[] target, ref int offset)
            {
                for (int i = 0; i < target.Length; i++)
                {
                    if (Items.TryGetValue(offset + i, out item))
                        target[i].item = item;
                }
                offset += target.Length;
            }
            int index = 0;
            fill(ref inv.Craft, ref index);
            fill(ref inv.Armor, ref index);
            fill(ref inv.mainInv, ref index);
            fill(ref inv.hotbar, ref index);
            if (Items.TryGetValue(45, out item))
                inv.Offhand.item = item;
            if (Items.TryGetValue(46, out item))
                inv.CarriedItem.item = item;
        }
    }
}