namespace Inventory
{
    public struct IndexedItem
    {
        public Item item;
        public string[] allowedItems;//empty -> allow all, 

        public IndexedItem(Item item, string[] allowed)
        {
            this.item = item;
            this.allowedItems = allowed;
        }
    }
}
