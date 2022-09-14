using System;
using System.Collections.Generic;

public static class PackageRegistry
{
    public static Dictionary<State, Dictionary<int, List<IPacketListener>>> registered =
        new Dictionary<State, Dictionary<int, List<IPacketListener>>>();
    public static Dictionary<int, Type> BoundToClient = new Dictionary<int, Type>();
    public static Dictionary<int, Type> BoundToServer = new Dictionary<int, Type>();


    public static void Register(int packetid, State state, IPacketListener obj)
    {
        if (!registered.ContainsKey(state))
        {
            registered.Add(state, new Dictionary<int, List<IPacketListener>>()
            {
                { packetid, new List<IPacketListener>() { obj } }
            });
            return;
        }
        if (!registered[state].ContainsKey(packetid))
        {
            registered[state].Add(packetid, new List<IPacketListener>() { obj });
            return;
        }
        registered[state][packetid].Add(obj);
    }

}