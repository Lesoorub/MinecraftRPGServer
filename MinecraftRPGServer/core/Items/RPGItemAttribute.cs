using System;

namespace Inventory
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class RPGItemAttribute : Attribute
    {
        public string name;
        public RPGItemAttribute(string name)
        {
            this.name = name;
        }
    }

}