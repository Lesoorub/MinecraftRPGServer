using Inventory;
using NBT;
using System.Runtime.CompilerServices;

public class InventoryWindowWatcher : DataWatcher<InventoryWindowWatcher.InventoryArgs>
{
    public struct InventoryArgs
    {
        public int index;
        public Item item;

        public InventoryArgs(int index, Item item)
        {
            this.index = index;
            this.item = item;
        }
    }
    PlayerInventoryWindow window;
    Item[] dump;
    public InventoryWindowWatcher(PlayerInventoryWindow window)
    {
        this.window = window;
        dump = new Item[46];
        for (int k = 1; k < 46; k++)
        {
            var item = window.GetItem(k);
            if (item != null)
                dump[k] = (Item)item.Clone();
        }
    }

    public override void Update()
    {
        for (int k = 1; k < 46; k++)
        {
            var item = window.GetItem(k);
            if (hasItemChanged(item, dump[k]))
            {
                InvokeOnChange(window, new InventoryArgs(k, item));
                dump[k] = item != null ? (Item)item.Clone() : null;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool hasItemChanged(Item real, Item dumpItem)
    {
        if (real == null && dumpItem == null) return false;
        if (real != null && dumpItem != null) return 
            real.ItemID != dumpItem.ItemID || 
            real.ItemCount != dumpItem.ItemCount || 
            !NBTTag.Equals(real.NBT, dumpItem.NBT);
        return true;
    }
}