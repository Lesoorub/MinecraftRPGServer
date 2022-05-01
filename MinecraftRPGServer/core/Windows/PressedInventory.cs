using System.Linq;

public class PressedInventory
{
    public Item[] mainInv = new Item[27];
    public Item[] hotbar = new Item[9];
    public Item[] Armor = new Item[4];
    public Item[] Craft = new Item[4];
    public Item Offhand;
    public Item CarriedItem;
    public PressedInventory(InventoryOfPlayer inv)
    {
        mainInv = inv.mainInv.Select(x => x.item).ToArray();
        hotbar = inv.hotbar.Select(x => x.item).ToArray();
        Armor = inv.Armor.Select(x => x.item).ToArray();
        Craft = inv.Craft.Select(x => x.item).ToArray();
        Offhand = inv.Offhand.item;
        CarriedItem = inv.CarriedItem.item;
    }
    public void UnloadTo(ref InventoryOfPlayer inv)
    {
        void fill (ref IndexedItem[] target, Item[] from)
        {
            for (int k = 0; k < target.Length; k++)
                target[k].item = from[k];
        }
        fill(ref inv.mainInv, mainInv);
        fill(ref inv.hotbar, hotbar);
        fill(ref inv.Armor, Armor);
        fill(ref inv.Craft, Craft);
        inv.Offhand.item = Offhand;
        inv.CarriedItem.item = CarriedItem;
    }
}