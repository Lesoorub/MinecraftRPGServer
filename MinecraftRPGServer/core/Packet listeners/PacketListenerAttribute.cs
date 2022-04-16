using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
sealed class PacketListenerAttribute : Attribute
{
    public int packet_id;
    public State state;
    public PacketListenerAttribute(int packet_id, State state)
    {
        this.packet_id = packet_id;
        this.state = state;
    }
}