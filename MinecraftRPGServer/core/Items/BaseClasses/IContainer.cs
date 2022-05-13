namespace Inventory.Items
{
    public interface IContainer
    {
        IndexedItem[] slots { get; set; }
        void OpenWindow(Player player);
    }
}