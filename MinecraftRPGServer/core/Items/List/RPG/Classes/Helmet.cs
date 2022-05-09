using System.Collections.Generic;
using static Inventory.Item;

namespace Inventory.Items
{
    public class Helmet : Armor
    {
        public override string Type => "Helmet";
        public Helmet(ItemID itemID) : base(itemID) { }
        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("minecraft:helmet");
            return t;
        }
        protected override void Equip(Player player)
        {
            Swap(ref player.inventory.hotbar[player.SelectedSlot].item, ref player.inventory.Armor[0].item);
        }
    }
}
