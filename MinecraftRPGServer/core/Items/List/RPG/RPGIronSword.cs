namespace Inventory.Items
{
    [RPGItem("iron_sword")]
    public class RPGIronSword : IronSword
    {
        public RPGIronSword()
        {
            MinDamage = 3;
            MaxDamage = 6;
        }
    }
}