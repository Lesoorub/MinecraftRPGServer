using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
sealed class ItemAttribute : Attribute
{
    public string nameid;
    public ItemAttribute(string nameid) 
    { 
        this.nameid = nameid;
    }
}
