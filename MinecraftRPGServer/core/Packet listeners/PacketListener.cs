using System;
using MineServer;

public class PacketListener : IPacketListener
{
    public MinecraftCore server { get; set; }
    public static object Parse(MinecraftPacket packet, Type type)
    {
        var parsed = Activator.CreateInstance(type);
        (parsed as MSerializableToBytes).FromByteArray(packet.data, 0, out var l);
        return Convert.ChangeType(parsed, type);
    }
    public virtual void OnPacketRecieved(IClient client, IPacket packet) { }
}