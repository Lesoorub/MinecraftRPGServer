namespace Inventory
{
    public sealed class ChestWindow : AbstractWindow
    {
        public override int Type => 2;
        public override string Name => "minecraft:generic_9x3";
        public ChestWindow(InventoryOfPlayer player, IndexedItem[] inventory) : base(player)
        {
            this.inventory = inventory;
        }
        public override IndexedItem GetSlot(int index)
        {
            if (index <= 26) return inventory[index];
            if (index >= 27 && index <= 53) return pinv.mainInv[index - 27];
            if (index >= 54 && index <= 52) return pinv.hotbar[index - 54];
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
            if (index <= 26) { inventory[index].item = newItem; return; }
            if (index >= 27 && index <= 53) { pinv.mainInv[index - 27].item = newItem; return; }
            if (index >= 54 && index <= 52) { pinv.hotbar[index - 54].item = newItem; return; }
        }
    }
}