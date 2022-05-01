public sealed class ChestWindow : AbstractWindow
{
    public override int Type => 2;
    public override string Name => "minecraft:generic_9x3";
    public ChestWindow(InventoryOfPlayer player, Slot[] inventory) : base(player)
    {
        this.inventory = inventory;
    }
    public override Item GetItem(int index)
    {
        if (index <= 26) return inventory[index];
        if (index >= 27 && index <= 53) return pinv.mainInv[index - 27].item;
        if (index >= 54 && index <= 52) return pinv.hotbar[index - 54].item;
        return null;
    }
    public override void SetSlot(int index, Item newItem)
    {
        if (newItem != null && newItem.ItemCount <= 0)
            newItem = null;
        if (index <= 26) { inventory[index] = newItem; return; }
        if (index >= 27 && index <= 53) { pinv.mainInv[index - 27].item = newItem; return; }
        if (index >= 54 && index <= 52) { pinv.hotbar[index - 54].item = newItem; return; }
    }
}