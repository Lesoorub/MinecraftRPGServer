﻿using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ChatCommandAttribute : Attribute
{
    public ChatCommandAttribute() { }
}
