using System.Linq;
public sealed class PlayerInventoryWindow : AbstractWindow
{
    public override Slot[] Slots => Combine(
            GetCraftingOutput(pinv.Craft.Select(x => x.item).ToArray()),
            pinv.Craft.Select(x => x.item).ToArray(),
            pinv.Armor.Select(x => x.item).ToArray(),
            pinv.mainInv.Select(x => x.item).ToArray(),
            pinv.hotbar.Select(x => x.item).ToArray(),
            pinv.Offhand.item);
    public override int Type => -1;
    public override string Name => null;
    public PlayerInventoryWindow(InventoryOfPlayer player) : base(player) { }
    Slot GetCraftingOutput(Item[] craft) => new Slot();
    public override Item GetItem(int index)
    {
        if (index == 0) return GetCraftingOutput(pinv.Craft.Select(x => x.item).ToArray());
        if (index >= 1 && index <= 4) return pinv.Craft[index - 1].item;
        if (index >= 5 && index <= 8) return pinv.Armor[index - 5].item;
        if (index >= 9 && index <= 35) return pinv.mainInv[index - 9].item;
        if (index >= 36 && index <= 44) return pinv.hotbar[index - 36].item;
        if (index == 45) return pinv.Offhand.item;
        return null;
    }
    public override void SetSlot(int index, Item newItem)
    {
        if (newItem != null && newItem.ItemCount <= 0)
            newItem = null;
        if (index >= 1 && index <= 4) { pinv.Craft[index - 1].item = newItem; return; }
        if (index >= 5 && index <= 8) { pinv.Armor[index - 5].item = newItem; return; }
        if (index >= 9 && index <= 35) { pinv.mainInv[index - 9].item = newItem; return; }
        if (index >= 36 && index <= 44) { pinv.hotbar[index - 36].item = newItem; return; }
        if (index == 45) { pinv.Offhand.item = newItem; return; }
    }
}
