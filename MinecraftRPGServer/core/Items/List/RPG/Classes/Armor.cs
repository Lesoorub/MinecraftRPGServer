using System.Collections.Generic;

namespace Inventory.Items
{
    public class Armor : RPGItem, IUsable
    {
        public virtual float Health { get; set; }

        public Armor(ItemID itemID) : base(itemID) { }

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