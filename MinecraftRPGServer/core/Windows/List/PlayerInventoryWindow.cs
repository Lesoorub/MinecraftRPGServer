public sealed class PlayerInventoryWindow : AbstractWindow
{
    public override Slot[] Slots => Combine(
            GetCraftingOutput(player.Craft),
            player.Craft,
            player.Armor,
            player.mainInv,
            player.hotbar,
            player.Offhand);
    public override int Type => -1;
    public override string Name => null;
    public PlayerInventoryWindow(InventoryOfPlayer player) : base(player) { }
    Slot GetCraftingOutput(Item[] craft) => new Slot();
    public override Item GetItem(int index)
    {
        if (index == 0) return GetCraftingOutput(player.Craft);
        if (index >= 1 && index <= 4) return player.Craft[index - 1];
        if (index >= 5 && index <= 8) return player.Armor[index - 5];
        if (index >= 9 && index <= 35) return player.mainInv[index - 9];
        if (index >= 36 && index <= 44) return player.hotbar[index - 36];
        if (index == 45) return player.Offhand;
        return null;
    }
    public override void SetSlot(int index, Item newItem)
    {
        void f()
        {
            if (index >= 1 && index <= 4) { player.Craft[index - 1] = newItem; return; }
            if (index >= 5 && index <= 8) { player.Armor[index - 5] = newItem; return; }
            if (index >= 9 && index <= 35) { player.mainInv[index - 9] = newItem; return; }
            if (index >= 36 && index <= 44) { player.hotbar[index - 36] = newItem; return; }
            if (index == 45) { player.Offhand = newItem; return; }
        }
        if (newItem != null && newItem.ItemCount <= 0)
            newItem = null;
        f();
        OnItemChange_Invoke(newItem, index);
    }
}
