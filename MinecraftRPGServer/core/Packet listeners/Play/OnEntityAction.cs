using MineServer;
using Packets.Play;

[PacketListener(0x1B, State.Play)]
public class OnEntityAction : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var pack = packet as EntityAction;
        if (player == null) return;
        if (player.EntityID != pack.EntityID)
        {
            throw new System.Exception("What is it?");
        }
        switch (pack.ActionID)
        {
            case EntityAction.ActionType.StartSneaking:
                player.IsSneaking = true; break;
            case EntityAction.ActionType.StopSneaking:
                player.IsSneaking = false; break;
            case EntityAction.ActionType.StartSprinting:
                player.IsSprinting = true; break;
            case EntityAction.ActionType.StopSprinting:
                player.IsSprinting = false; break;
        }
    }
}
