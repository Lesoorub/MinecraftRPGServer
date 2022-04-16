using MineServer;
using Packets.Status;

[PacketListener(0x01, State.Status)]
public sealed class Ping : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var ping = packet as Packets.Status.Ping;
        if (ping == null) return;
        client.network.Send(new Pong() { Payload = ping.Payload });
    }
}