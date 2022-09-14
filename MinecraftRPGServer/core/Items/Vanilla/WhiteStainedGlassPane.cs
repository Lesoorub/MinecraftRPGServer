namespace Inventory.Items
{
    [Item(ItemNameID.white_stained_glass_pane)]
    public class WhiteStainedGlassPane : Item
    {
        public override bool sendNBT => true;
        public static WhiteStainedGlassPane Instance => new WhiteStainedGlassPane()
        {
            ItemID = ItemNameID.white_stained_glass_pane,
            ItemCount = 1
        };
        public WhiteStainedGlassPane()
        {
            Name = " ";
        }
    }
}