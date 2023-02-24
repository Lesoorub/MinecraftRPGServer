using MineServer;
using Packets.Play;

[PacketListener(0x1A, State.Play)]
public class OnPlayerDigging : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var playerDigging = packet as PlayerDigging;
        var player = client as Player;
        if (playerDigging == null || player == null) return;

        if (playerDigging.status == PlayerDigging.Status.FinishedDigging ||
            playerDigging.status == PlayerDigging.Status.CancelledDigging ||
            playerDigging.status == PlayerDigging.Status.StartedDigging)
        {
            void SendOldBlock()
            {
                player.network.Send(new BlockChange()
                {
                    BlockID = new VarInt(player.world.GetBlock((v3i)playerDigging.Location).StateID),
                    Location = playerDigging.Location,
                });
            }
            if (!player.rpgserver.config.world.AllowBreakBlocks)
                SendOldBlock();
            else
            {
                switch (playerDigging.status)
                {
                    case PlayerDigging.Status.StartedDigging:
                        if (player.Gamemode == GamemodeType.Creative)
                        {
                            if (!player.world.SetBlock(player,
                                   playerDigging.Location.x,
                                   (short)playerDigging.Location.y,
                                   playerDigging.Location.z,
                                   new BlockState(0)))
                                SendOldBlock();
                        }
                        else if (player.Gamemode == GamemodeType.Survival)
                            player.worldController.StartBreakBlock(playerDigging.Location);
                        break;
                    case PlayerDigging.Status.CancelledDigging:
                        if (player.Gamemode == GamemodeType.Survival)
                            player.worldController.EndlBreakBlock();
                        break;
                    case PlayerDigging.Status.FinishedDigging:
                        if (player.Gamemode == GamemodeType.Survival &&
                            player.worldController.canBreak(playerDigging.Location))
                        {
                            if (!player.world.SetBlock(player,
                                playerDigging.Location.x,
                                (short)playerDigging.Location.y,
                                playerDigging.Location.z,
                                new BlockState(0)))
                                SendOldBlock();
                            player.worldController.EndlBreakBlock();
                        }
                        break;
                }
            }
            return;
        }

        switch (playerDigging.status)
        {
            case PlayerDigging.Status.ShootArrowOrFinishEathing:
                (player.MainHand as IUsingFinish)?.UsingFinish(player);
                break;
            case PlayerDigging.Status.DropItem:
                player.DropItem(36 + player.SelectedSlot, 1);
                break;
            case PlayerDigging.Status.DropItemStack:
                player.DropItem(36 + player.SelectedSlot, player.MainHand.ItemCount);
                break;
        }
    }
}
