using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
sealed class ChatCommandAttribute : Attribute
{
    public ChatCommandAttribute() { }
}
