using MineServer;

[PacketListener(0x28, State.Play)]
public class OnCreativeInventoryAction : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var creativeInventoryAction = packet as Packets.Play.CreativeInventoryAction;
        if (player == null || creativeInventoryAction == null) return;
        var item = player.inventoryWindow.GetItem(creativeInventoryAction.Slot);
        if (item != null && item is Inventory.Items.RPGItem rpgItem)
        {
            player.SendInventory();
            return;
        }
        player.inventoryWindow.SetSlot(creativeInventoryAction.Slot, creativeInventoryAction.ClickedItem);
    }
}