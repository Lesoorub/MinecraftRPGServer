using MineServer;
using Packets.Play;

[PacketListener(0x0F, State.Play)]
public class OnKeepAlive : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var keepAlive = packet as KeepAlive_serverbound;
        var player = client as Player;
        if (keepAlive == null || player == null) return;
        player.keepAlive.OnKeepAliveRecieved(keepAlive);
    }
}
