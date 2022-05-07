using System.Collections.Generic;

namespace Inventory.Items
{
    public abstract class Sword : RPGItem
    {
        public float MinDamage;
        public float MaxDamage;
        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("minecraft:sword");
            return t;
        }
    }
}