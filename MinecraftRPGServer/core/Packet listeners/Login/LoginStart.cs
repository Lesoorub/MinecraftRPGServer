using MineServer;

[PacketListener(0x00, State.Login)]
public class LoginStart : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var startlogin = packet as Packets.Login.LoginStart;
        if (startlogin == null) return;
        (client as ConnectedClient).username = startlogin.name;
        Authentication.Yggdrasil.OnLoginStart(client);
    }
}
