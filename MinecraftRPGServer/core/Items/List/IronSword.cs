namespace Inventory.Items
{
    [Item("minecraft:iron_sword")]
    public class IronSword : Sword
    {
        public IronSword()
        {
            MinDamage = 3;
            MaxDamage = 6;
        }
    }

}