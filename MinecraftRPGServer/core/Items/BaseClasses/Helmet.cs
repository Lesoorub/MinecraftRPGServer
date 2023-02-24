using System.Collections.Generic;

namespace Inventory.Items
{
    public class Helmet : Armor
    {
        public override string Type => "Helmet";
        public Helmet(ItemNameID itemID) : base(itemID) { }
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
