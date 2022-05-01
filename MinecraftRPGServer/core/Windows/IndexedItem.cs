public struct IndexedItem
{
    public Item item;
    public SlotType type;

    public IndexedItem(Item item, SlotType type = SlotType.All)
    {
        this.item = item;
        this.type = type;
    }
}
