public class InventoryOfPlayer
{
    public enum ItemPlace : byte
    {
        hotbar,
        mainInv,
        armor,
        craft,
        offhand,
        carriedItem
    }


    public IndexedItem[] mainInv = new IndexedItem[27];
    public IndexedItem[] hotbar = new IndexedItem[9];
    public IndexedItem[] Armor = new IndexedItem[4]
    {
        new IndexedItem(null, SlotType.Armor | SlotType.Helmet),
        new IndexedItem(null, SlotType.Armor | SlotType.Chestplate),
        new IndexedItem(null, SlotType.Armor | SlotType.Leggins),
        new IndexedItem(null, SlotType.Armor | SlotType.Boots),
    };
    public IndexedItem[] Craft = new IndexedItem[4];
    public IndexedItem Offhand;
    public IndexedItem CarriedItem;

    public void OnItemChange_Invoke(Item item, ItemPlace place) => OnItemChanged?.Invoke(item, place);
    public delegate void ItemChangedArgs(Item item, ItemPlace place);
    public event ItemChangedArgs OnItemChanged;

    public bool AddItem(Item item, out Item rest)
    {
        bool Add(ref Item target)
        {
            if (target == null)
            {
                target = item;
                return false;
            }
            if (target.ItemCount + item.ItemCount <= 64)
            {
                target.ItemCount += item.ItemCount;
                return false;
            }
            else
            {
                item.ItemCount -= (byte)(64 - target.ItemCount);
                target.ItemCount = 64;
                return true;
            }
        }
        rest = null;
        int index;
        if (FindSpaceForItem(hotbar, item, out index))
        {
            if (Add(ref hotbar[index].item))
                rest = item;
            return true;
        }
        if (FindSpaceForItem(mainInv, item, out index))
        {
            if (Add(ref mainInv[index].item))
                rest = item;
            return true;
        }
        if (FindSpaceForItem(new IndexedItem[] { Offhand }, item, out _))
        {
            if (Add(ref Offhand.item))
                rest = item;
            return true;
        }
        return false;
    }

    bool FindSpaceForItem(IndexedItem[] arr, Item item, out int index)
    {
        for (int k = 0; k < arr.Length; k++)
        {
            var i = arr[k];
            if (i.item == null || !i.item.Present) continue;
            if (i.item.ItemID.value.Equals(item.ItemID.value) &&//Совпадение по ID
                i.item.NBT.Bytes.Equals(item.NBT.Bytes)) //Совпадение по NBT
            {
                index = k;
                return true;
            }
        }
        for (int k = 0; k < arr.Length; k++)
        {
            var i = arr[k];
            if (i.item == null || !i.item.Present)
            {
                index = k;
                return true;
            }
        }
        index = -1;
        return false;
    }

    public Item FindItem(string nameid)
    {
        if (!Item.NameIDs.TryGetValue(nameid, out var itemid)) return null;
        bool find(IndexedItem[] arr, out int index)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                var i = arr[k];
                if (i.item != null && i.item.ItemID.value.Equals(itemid))
                {
                    index = k;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        int t;
        if (find(mainInv, out t)) return mainInv[t].item;
        if (find(hotbar, out t)) return hotbar[t].item;
        if (Offhand.item.ItemID.value.Equals(itemid)) return Offhand.item;
        return null;
    }
}
