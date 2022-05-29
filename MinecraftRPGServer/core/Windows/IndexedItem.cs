namespace Inventory
{
    public struct IndexedItem
    {
        public Item item;
        public string[] allowedItems;//empty -> allow all, 
        public string[] blacklistItems;//empty -> allow all, 
        public bool readOnly;

        public IndexedItem(Item item, string[] allowed)
        {
            this.item = item;
            this.allowedItems = allowed;
            this.blacklistItems = new string[] {};
            readOnly = false;
        }
        public IndexedItem(Item item, string[] allowed, string[] blacklist)
        {
            this.item = item;
            this.allowedItems = allowed;
            this.blacklistItems = blacklist;
            readOnly = false;
        }
    }
}
