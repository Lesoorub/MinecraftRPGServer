using System.Linq;
using System.Runtime.CompilerServices;
using Inventory;
using Inventory.Items;

public class InventoryWatcher : DataWatcher<InventoryWatcher.InventoryArgs>
{
    public struct InventoryArgs
    {
        public IndexedItem slot;

        public InventoryArgs(IndexedItem slot)
        {
            this.slot = slot;
        }
    }
    InventoryOfPlayer inv;
    PressedInventory dump;
    public InventoryWatcher(InventoryOfPlayer inventory)
    {
        inv = inventory;
        dump = new PressedInventory(inv);

        for (int k = 0; k <= 46; k++)
            if (dump.Items.TryGetValue(k, out var item))
                dump.Items[k] = (Item)item.Clone();
    }

    public override void Update()
    {
        void f(IndexedItem a, ref Item b)
        {
            if (hasItemChanged(a.item, b))
            {
                b = (Item)a.item.Clone();
                InvokeOnChange(inv, new InventoryArgs(a));
            }
        }

        //TODO У меня там в dump есть Items, это словарь предметов.
        //По нему нужно пройтись и посмотреть изменения с помощью функции f.
        //result:
        var items = inv.mainInv
                .Concat(inv.hotbar)
                .Concat(inv.Armor)
                .Concat(inv.Craft)
                .Concat(new IndexedItem[] { inv.Offhand, inv.CarriedItem }).ToArray();
        foreach (var pair in dump.Items)
        {
            var i = pair.Value;
            f(items[pair.Key], ref i);
            dump.Items[pair.Key] = i;
        }

        //f(inv.CarriedItem, ref dump.CarriedItem);
        //f(inv.Offhand, ref dump.Offhand);
        //int k;
        //for (k = 0; k < inv.hotbar.Length; k++)
        //    f(inv.hotbar[k], ref dump.hotbar[k]);
        //for (k = 0; k < inv.mainInv.Length; k++)
        //    f(inv.mainInv[k], ref dump.mainInv[k]);
        //for (k = 0; k < inv.Craft.Length; k++)
        //    f(inv.Craft[k], ref dump.Craft[k]);
        //for (k = 0; k < inv.Armor.Length; k++)
        //    f(inv.Armor[k], ref dump.Armor[k]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool hasItemChanged(Item real, Item dumpItem)
    {
        return !ReferenceEquals(real, dumpItem);
    }
}
