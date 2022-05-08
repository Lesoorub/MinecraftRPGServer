using MineServer;
using Packets.Play;

[PacketListener(0x04, State.Play)]
public class OnClientStatus : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        //var player = client as Player;
        //var pack = packet as ClientStatus;
        //if (player == null) return;
        //if (pack.ActionID == ClientStatus.ActionIDType.PerformRespawn)
        //    player.RespawnPlayer();
    }
}