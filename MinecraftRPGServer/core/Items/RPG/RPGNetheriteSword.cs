using System.Collections.Generic;

namespace Inventory.Items
{
    [RPGItem("netherite_sword")]
    public class RPGNetheriteSword : NetheriteSword
    {
        public RPGNetheriteSword()
        {
            Name = "netherite sword";
            MinDamage = 15;
            MaxDamage = 25;
        }
    }
}