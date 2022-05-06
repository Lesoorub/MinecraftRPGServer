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
        bool tryAdd(ref Item i, IndexedItem[] to)
        {
            for (int k = 0; k < to.Length; k++)
            {
                var t = to[k];
                if (t.item == null)
                {
                    to[k].item = i;
                    i = null;
                    return true;
                }
                if (ItemEquals(i, t.item) && CanPlace(t, i))
                {
                    if (TryMove(ref to[k].item, ref i, i.ItemCount))
                        if (i == null || i.ItemCount == 0)
                            return true;
                }
            }
            return false;
        }

        if (tryAdd(ref item, hotbar))
            return true;
        if (tryAdd(ref item, mainInv))
            return true;
        if (tryAdd(ref item, new IndexedItem[] { Offhand }))
            return true;
        return false;
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
