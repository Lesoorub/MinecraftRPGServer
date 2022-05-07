using System.Collections.Generic;

namespace Inventory.Items
{
    public class Armor : RPGItem, IUsable
    {
        public float Health;

        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("minecraft:armor");
            return t;
        }
        public void Use(Player player)
        {
            Equip(player);
        }

        protected virtual void Equip(Player player)
        {

        }
    }
}