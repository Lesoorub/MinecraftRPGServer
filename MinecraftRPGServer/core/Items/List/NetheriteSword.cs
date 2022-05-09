namespace Inventory.Items
{
    [Item(ItemID.netherite_sword)]
    public class NetheriteSword : Sword
    {
        public NetheriteSword()
        {
            MinDamage = 15;
            MaxDamage = 25;
        }
    }

}