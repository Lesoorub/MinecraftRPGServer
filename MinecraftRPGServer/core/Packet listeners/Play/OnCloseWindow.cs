using MineServer;
using Packets.Play;

[PacketListener(0x09, State.Play)]
public class OnCloseWindow : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var pack = packet as CloseWindow_serverbound;
        if (pack == null || player == null) return;
        if (pack.WindowID != 0)
            player.CloseWindow(pack.WindowID);
        player.api.SendInventory();
    }
}