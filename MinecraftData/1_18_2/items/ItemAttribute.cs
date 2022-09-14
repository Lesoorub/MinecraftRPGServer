using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace MinecraftData._1_18_2.items.minecraft
{
    public partial class ItemAttribute : Attribute
    {
        public ItemNameID nameID;
        public ItemAttribute(ItemNameID nameID)
        {
            this.nameID = nameID;
        }
    }
}
