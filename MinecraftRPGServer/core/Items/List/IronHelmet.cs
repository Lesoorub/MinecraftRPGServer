namespace Inventory.Items
{
    [Item(ItemID.iron_helmet)]
    public class IronHelmet : Helmet
    {
        public IronHelmet()
        {
            Health = 10;
        }
    }

}