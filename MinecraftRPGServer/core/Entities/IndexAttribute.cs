using System;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
sealed class IndexAttribute : Attribute
{
    public byte index;
    public IndexAttribute(byte index)
    {
        this.index = index;
    }
}
