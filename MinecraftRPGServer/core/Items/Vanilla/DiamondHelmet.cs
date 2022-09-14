using System;
using System.Collections.Generic;

namespace Inventory.Items
{
    [Item(ItemNameID.diamond_helmet)]
    public class DiamondHelmet : Helmet
    {
        public DiamondHelmet() : base(ItemNameID.diamond_helmet) { }
    }
}