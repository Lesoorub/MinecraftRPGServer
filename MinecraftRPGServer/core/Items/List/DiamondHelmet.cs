using System;

namespace Inventory.Items
{
    [Item(ItemID.diamond_helmet)]
    public class DiamondHelmet : Helmet
    {
        public DiamondHelmet() : base(ItemID.diamond_helmet) { }
    }
}