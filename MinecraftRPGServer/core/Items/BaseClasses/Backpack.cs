namespace Inventory.Items
{
    [RPGItem("backpack")]
    public class Backpack : Leather, IContainer, IUsable
    {
        public IndexedItem[] slots { get; set; } = new IndexedItem[27];
        public override CustomModelData model => CustomModelData.backpack0;
        public void OpenWindow(Player player)
        {
            player.OpenWindow(new ChestWindow(player.inventory, slots)
            {
                WindowTitle = Chat.ColoredText("&8Backpack")
            });
        }

        public void Use(Player player)
        {
            OpenWindow(player);
        }
    }
}