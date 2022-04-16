using Packets.Handhaking;
using MineServer;

[PacketListener(0x00, State.Handhaking)]
public sealed class Handhaking : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var con_client = client as ConnectedClient;
        if (con_client == null) return;
        var h = packet as Handhake;
        con_client.protocolVersion = h.protocol_version;
        switch (h.next_state)
        {
            case 1: con_client.current_state = State.Status; break;
            case 2:
                if (SupportedProtocol.allprotocols.ContainsKey(h.protocol_version))
                    con_client.current_state = State.Login;
                else
                    client.network.Disconnect();//unsupported protocol version
                break;
        }
    }
}