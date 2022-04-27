using MineServer;
using System.Linq;
using Packets.Play;

[PacketListener(0x1A, State.Play)]
public class OnPlayerDigging : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var playerDigging = packet as PlayerDigging;
        var player = client as Player;
        if (playerDigging == null || player == null) return;

        if (!player.rpgserver.config.AllowBreakBlocks)
            player.network.Send(new BlockChange()
            {
                BlockID = new VarInt(player.world.GetBlock((v3i)playerDigging.Location).StateID),
                Location = playerDigging.Location,
            });

        switch (playerDigging.status)
        {
            case PlayerDigging.Status.ShootArrowOrFinishEathing:
                (player.SelectedItem as IUsingFinish)?.UsingFinish(player);
                break;
            case PlayerDigging.Status.DropItem:
                player.DropItem(36 + player.SelectedSlot, 1);
                break;
            case PlayerDigging.Status.DropItemStack:
                player.DropItem(36 + player.SelectedSlot, player.SelectedItem.ItemCount);
                break;
        }
    }
}