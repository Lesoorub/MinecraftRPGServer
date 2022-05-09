namespace Inventory.Items
{
    [Item(ItemID.iron_sword)]
    public class IronSword : Sword
    {
        public IronSword()
        {
            MinDamage = 3;
            MaxDamage = 6;
        }
    }

}