using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
sealed class ItemAttribute : Attribute
{
    public ItemID itemID;
    public ItemAttribute(ItemID itemID) 
    { 
        this.itemID = itemID;
    }
}
