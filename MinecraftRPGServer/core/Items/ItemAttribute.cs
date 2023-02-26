using System;

namespace Inventory
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ItemAttribute : Attribute
    {
        public ItemNameID itemID;
        public ItemAttribute(ItemNameID itemID)
        {
            this.itemID = itemID;
        }
    }
}