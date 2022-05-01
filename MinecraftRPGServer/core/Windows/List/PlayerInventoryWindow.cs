using System.Linq;
public sealed class PlayerInventoryWindow : AbstractWindow
{
    public override Slot[] Slots => Combine(
            GetCraftingOutput(player.Craft.Select(x => x.item).ToArray()),
            player.Craft.Select(x => x.item).ToArray(),
            player.Armor.Select(x => x.item).ToArray(),
            player.mainInv.Select(x => x.item).ToArray(),
            player.hotbar.Select(x => x.item).ToArray(),
            player.Offhand.item);
    public override int Type => -1;
    public override string Name => null;
    public PlayerInventoryWindow(InventoryOfPlayer player) : base(player) { }
    Slot GetCraftingOutput(Item[] craft) => new Slot();
    public override Item GetItem(int index)
    {
        if (index == 0) return GetCraftingOutput(player.Craft.Select(x => x.item).ToArray());
        if (index >= 1 && index <= 4) return player.Craft[index - 1].item;
        if (index >= 5 && index <= 8) return player.Armor[index - 5].item;
        if (index >= 9 && index <= 35) return player.mainInv[index - 9].item;
        if (index >= 36 && index <= 44) return player.hotbar[index - 36].item;
        if (index == 45) return player.Offhand.item;
        return null;
    }
    public override void SetSlot(int index, Item newItem)
    {
        void f()
        {
            if (index >= 1 && index <= 4) { player.Craft[index - 1].item = newItem; return; }
            if (index >= 5 && index <= 8) { player.Armor[index - 5].item = newItem; return; }
            if (index >= 9 && index <= 35) { player.mainInv[index - 9].item = newItem; return; }
            if (index >= 36 && index <= 44) { player.hotbar[index - 36].item = newItem; return; }
            if (index == 45) { player.Offhand.item = newItem; return; }
        }
        if (newItem != null && newItem.ItemCount <= 0)
            newItem = null;
        f();
        OnItemChange_Invoke(newItem, index);
    }
}
