using MineServer;

[PacketListener(0x28, State.Play)]
public class OnCreativeInventoryAction : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var creativeInventoryAction = packet as Packets.Play.CreativeInventoryAction;
        if (player == null || creativeInventoryAction == null) return;
        player.inventoryWindow.SetSlot(creativeInventoryAction.Slot, creativeInventoryAction.ClickedItem);
    }
}