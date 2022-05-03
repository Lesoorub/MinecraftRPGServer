public struct IndexedItem
{
    public Item item;
    public SlotType type;
    public int[] allowedIDs;

    public IndexedItem(Item item, SlotType type = SlotType.Any)
    {
        this.item = item;
        this.type = type;
        allowedIDs = new int[0];
    }
}
