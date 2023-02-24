using MineServer;

[PacketListener(0x08, State.Play)]
public class OnClickWindow : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var clickWindow = packet as Packets.Play.ClickWindow;
        if (player == null || clickWindow == null) return;
        if (clickWindow.WindowID == 0)
        {
            if (!player.inventoryWindow.ClickWindow(player, clickWindow))
                player.SendInventory();
        }
        else
        {
            if (player.SecondWindow != null &&
                clickWindow.WindowID == player.SecondWindow.WindowID)
            {
                if (!player.SecondWindow.ClickWindow(player, clickWindow))
                    player.SecondWindow.SendItems(player);
            }
        }
        player.inventoryWatcher.Update();
    }
}
