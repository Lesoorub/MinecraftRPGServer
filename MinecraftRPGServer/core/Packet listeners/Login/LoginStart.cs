using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using Packets.Login;
using Packets.Play;

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
