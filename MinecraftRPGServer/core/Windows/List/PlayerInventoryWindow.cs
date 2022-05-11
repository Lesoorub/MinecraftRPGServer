using System.Linq;
namespace Inventory
{
    public sealed class PlayerInventoryWindow : AbstractWindow
    {
        private IndexedItem CraftOutput = new IndexedItem(null, new string[] { "readonly" });
        public override Slot[] Slots => Combine(
                CraftOutput,
                pinv.Craft,
                pinv.Armor,
                pinv.mainInv,
                pinv.hotbar,
                pinv.Offhand);
        public override int hotbarIndex => 36;
        public override int mainInvIndex => 9;
        public override int Type => -1;
        public PlayerInventoryWindow(InventoryOfPlayer player) : base(player) { }
        public override IndexedItem GetSlot(int index)
        {
            if (index == 0) return CraftOutput;
            if (index >= 1 && index <= 4) return pinv.Craft[index - 1];
            if (index >= 5 && index <= 8) return pinv.Armor[index - 5];
            if (index >= 9 && index <= 35) return pinv.mainInv[index - 9];
            if (index >= 36 && index <= 44) return pinv.hotbar[index - 36];
            if (index == 45) return pinv.Offhand;
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
            if (index >= 1 && index <= 4) { pinv.Craft[index - 1].item = newItem; return; }
            if (index >= 5 && index <= 8) { pinv.Armor[index - 5].item = newItem; return; }
            if (index >= 9 && index <= 35) { pinv.mainInv[index - 9].item = newItem; return; }
            if (index >= 36 && index <= 44) { pinv.hotbar[index - 36].item = newItem; return; }
            if (index == 45) { pinv.Offhand.item = newItem; return; }
        }
    }
}
