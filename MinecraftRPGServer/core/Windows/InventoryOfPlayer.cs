using static AbstractWindow.ItemMovement.AbstractClick;
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

    public bool AddItem(ref Item item)
    {
        throw new System.NotImplementedException();
        int find(Item i, IndexedItem[] to)
        {
            for (int k = 0; k < to.Length; k++)
            {
                var t = to[k];
                if (t.item == null || (ItemEquals(i, t.item) && CanPlace(t, i)))
                    return k;
            }
            return -1;
        }
        while (item.ItemCount > 0)
        {
            int index;
            if ((index = find(item, hotbar)) != -1)
            {
                var slot = hotbar[index];
                if (slot.item == null)
                {
                    slot.item = item;
                    return true;
                }
                if (TryMove(ref slot.item, ref item, item.ItemCount))
                    continue;
            }
            if ((index = find(item, mainInv)) != -1)
            {
                var slot = mainInv[index];
                if (slot.item == null)
                {
                    slot.item = item;
                    return true;
                }
                if (TryMove(ref slot.item, ref item, item.ItemCount))
                    continue;
            }
            if (find(item, new IndexedItem[] { Offhand }) != -1)
            {
                var slot = Offhand;
                if (slot.item == null)
                {
                    slot.item = item;
                    return true;
                }
                if (TryMove(ref slot.item, ref item, item.ItemCount))
                    continue;
            }
            return false;
        }
        return true;
    }
    public Item FindItem(string nameid)
    {
        if (!Item.NameIDs.TryGetValue(nameid, out var itemid)) return null;
        int find(IndexedItem[] arr)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                var i = arr[k];
                if (i.item != null && i.item.ItemID.value.Equals(itemid))
                {
                    return k;
                }
            }
            return -1;
        }
        int t;
        if ((t = find(mainInv)) != -1) return mainInv[t].item;
        if ((t = find(hotbar)) != -1) return hotbar[t].item;
        if (Offhand.item != null && Offhand.item.ItemID.value.Equals(itemid)) return Offhand.item;
        return null;
    }
}
