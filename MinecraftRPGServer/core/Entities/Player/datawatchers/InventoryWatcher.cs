using System.Linq;
using System.Runtime.CompilerServices;
using Inventory;

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
        dump.CarriedItem = (Item)dump.CarriedItem.Clone();
        dump.Offhand = (Item)dump.Offhand.Clone();
        dump.hotbar = dump.hotbar.Select(x => (Item)x.Clone()).ToArray();
        dump.mainInv = dump.mainInv.Select(x => (Item)x.Clone()).ToArray();
        dump.Craft = dump.Craft.Select(x => (Item)x.Clone()).ToArray();
        dump.Armor = dump.Armor.Select(x => (Item)x.Clone()).ToArray();
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
        f(inv.CarriedItem, ref dump.CarriedItem);
        f(inv.Offhand, ref dump.Offhand);
        int k;
        for (k = 0; k < inv.hotbar.Length; k++)
            f(inv.hotbar[k], ref dump.hotbar[k]);
        for (k = 0; k < inv.mainInv.Length; k++)
            f(inv.mainInv[k], ref dump.mainInv[k]);
        for (k = 0; k < inv.Craft.Length; k++)
            f(inv.Craft[k], ref dump.Craft[k]);
        for (k = 0; k < inv.Armor.Length; k++)
            f(inv.Armor[k], ref dump.Armor[k]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool hasItemChanged(Item real, Item dumpItem)
    {
        return !ReferenceEquals(real, dumpItem);
    }
}
