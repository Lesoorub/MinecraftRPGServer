using static Inventory.Item;
using System.Linq;

namespace Inventory
{
    public class InventoryOfPlayer
    {
        public IndexedItem[] mainInv = new IndexedItem[27];
        public IndexedItem[] hotbar = new IndexedItem[9];
        public IndexedItem[] Armor = new IndexedItem[4]
        {
            new IndexedItem(null, new string[] { "minecraft:armor", "minecraft:helmet"}),
            new IndexedItem(null, new string[] { "minecraft:armor", "minecraft:chestplate"}),
            new IndexedItem(null, new string[] { "minecraft:armor", "minecraft:leggins"}),
            new IndexedItem(null, new string[] { "minecraft:armor", "minecraft:boots"}),
        };
        public IndexedItem[] Craft = new IndexedItem[4];
        public IndexedItem Offhand;
        public IndexedItem CarriedItem;

        //public void OnItemChange_Invoke(IndexedItem slot) => OnSlotChanged?.Invoke(slot);
        //public delegate void ItemChangedArgs(IndexedItem slot);
        //public event ItemChangedArgs OnSlotChanged;

        //public delegate void InventoryChangedArgs();
        //public event InventoryChangedArgs OnInventoryChanged;

        public void Init(Player player)
        {
            foreach (var rpgItem in mainInv
                .Concat(hotbar)
                .Concat(Armor)
                .Concat(Craft)
                .Concat(new IndexedItem[] { Offhand, CarriedItem })
                .Select(x => x.item as Items.RPGItem)
                .Where(x => x != null))
            {
                rpgItem.Init(player);
            }
        }

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
            if (!GetItemID(nameid, out var itemid)) return null;
            return FindItem(itemid);
        }
        public Item FindItem(ItemNameID itemid)
        {
            int find(IndexedItem[] arr)
            {
                for (int k = 0; k < arr.Length; k++)
                {
                    var i = arr[k];
                    if (i.item != null && i.item.ItemID.Equals(itemid))
                    {
                        return k;
                    }
                }
                return -1;
            }
            int t;
            if ((t = find(mainInv)) != -1) return mainInv[t].item;
            if ((t = find(hotbar)) != -1) return hotbar[t].item;
            if (Offhand.item != null && Offhand.item.ItemID.Equals(itemid)) return Offhand.item;
            return null;
        }
    }
}