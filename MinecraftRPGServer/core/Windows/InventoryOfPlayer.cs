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

    public Item[] mainInv = new Item[27];
    public Item[] hotbar = new Item[9];
    public Item[] Armor = new Item[4];
    public Item[] Craft = new Item[4];
    public Item Offhand;
    public Item CarriedItem;

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
            if (Add(ref hotbar[index]))
                rest = item;
            return true;
        }
        if (FindSpaceForItem(mainInv, item, out index))
        {
            if (Add(ref mainInv[index]))
                rest = item;
            return true;
        }
        if (FindSpaceForItem(new Item[] { Offhand }, item, out _))
        {
            if (Add(ref Offhand))
                rest = item;
            return true;
        }
        return false;
    }

    bool FindSpaceForItem(Item[] arr, Item item, out int index)
    {
        for (int k = 0; k < arr.Length; k++)
        {
            var i = arr[k];
            if (i == null || !i.Present) continue;
            if (i.ItemID.value.Equals(item.ItemID.value) &&//Совпадение по ID
                i.NBT.Bytes.Equals(item.NBT.Bytes)) //Совпадение по NBT
            {
                index = k;
                return true;
            }
        }
        for (int k = 0; k < arr.Length; k++)
        {
            var i = arr[k];
            if (i == null || !i.Present)
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
        bool find(Item[] arr, out int index)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                var i = arr[k];
                if (i.ItemID.value.Equals(itemid))
                {
                    index = k;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        int t;
        if (find(mainInv, out t)) return mainInv[t];
        if (find(hotbar, out t)) return hotbar[t];
        if (Offhand.ItemID.value.Equals(itemid)) return Offhand;
        return null;
    }
}
