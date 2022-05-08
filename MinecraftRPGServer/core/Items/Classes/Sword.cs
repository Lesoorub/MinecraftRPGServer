using System.Collections.Generic;

namespace Inventory.Items
{
    public abstract class Sword : RPGItem
    {
        public float MinDamage;
        public float MaxDamage;
        public virtual Sound AttackSound => new Sound(806, Categories.PLAYERS);
        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("minecraft:sword");
            return t;
        }
    }
}