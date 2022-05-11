namespace Inventory
{
    public sealed class ChestWindow : AbstractWindow
    {
        public override int Type => 2;
        public override Chat WindowTitle { get; set; } = Chat.ColoredText("Chest");
        public ChestWindow(InventoryOfPlayer player, IndexedItem[] inventory) : base(player)
        {
            this.inventory = inventory;
        }
        public override IndexedItem GetSlot(int index)
        {
            if (index < 0) return default;
            if (index <= 26) return inventory[index];
            if (index >= 27 && index <= 53) return pinv.mainInv[index - 27];
            if (index >= 54 && index <= 62) return pinv.hotbar[index - 54];
            return default;
        }
        public override Item GetItem(int index)
        {
            return GetSlot(index).item;
        }
        public override void SetSlot(int index, Item newItem)
        {
            if (newItem != null && newItem.ItemCount <= 0)
                newItem = null;
            if (index < 0) return;
            if (index <= 26) { inventory[index].item = newItem; return; }
            if (index >= 27 && index <= 53) { pinv.mainInv[index - 27].item = newItem; return; }
            if (index >= 54 && index <= 62) { pinv.hotbar[index - 54].item = newItem; return; }
        }
    }
}