[System.Obsolete("See player inventory v2.0")]
public class PlayerInventory : Window
{
    public override int WindowID { get => 0; }
    public override Item[] slots { get; set; } = new Item[46];
    public SlotsPart Crafting;
    public SlotsPart Armor;
    public SlotsPart MainInv;
    public SlotsPart Hotbar;
    public Item OffHand { get => slots[45]; set => slots[45] = value; }

    public Item Helmet { get => slots[5]; set => slots[5] = value; }
    public Item Chestplate { get => slots[6]; set => slots[6] = value; }
    public Item Leggins { get => slots[7]; set => slots[7] = value; }
    public Item Boots { get => slots[8]; set => slots[8] = value; }
    public PlayerInventory()
    {
        Crafting = new SlotsPart(this, 0, 5);
        Armor = new SlotsPart(this, 5, 4);
        MainInv = new SlotsPart(this, 9, 27);
        Hotbar = new SlotsPart(this, 36, 9);
    }

    public bool AddItem(Item item)
    {
        if (item == null) return false;
        for (int k = 0; k < 9; k++)
        {
            if (Hotbar[k] == null || !Hotbar[k].Present)
            {
                Hotbar[k] = item;
                return true;
            }
        }
        for (int k = 0; k < 27; k++)
        {
            if (MainInv[k] == null || !MainInv[k].Present)
            {
                MainInv[k] = item;
                return true;
            }
        }
        return false;
    }
}
