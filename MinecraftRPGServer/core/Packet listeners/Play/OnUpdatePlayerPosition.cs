using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MineServer;
using Packets.Play;

[PacketListener(0x11, State.Play)]
[PacketListener(0x12, State.Play)]
[PacketListener(0x13, State.Play)]
public class OnUpdatePlayerPosition : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = (Player)client;
        switch (packet.package_id)
        {
            case 0x11:
                var plpos = packet as PlayerPosition;
                player.ApplyNewPosition(new v3f((float)plpos.X, (float)plpos.FeetY, (float)plpos.Z));
                break;
            case 0x12:
                var plposandrot = packet as PlayerPositionAndRotation_serverbound;
                player.ApplyNewPositionAndRotation(
                    new v3f((float)plposandrot.X, (float)plposandrot.FeetY, (float)plposandrot.Z), 
                    new v2f(plposandrot.Yaw, plposandrot.Pitch));
                break;
            case 0x13:
                var plrot = packet as PlayerRotation;
                player.ApplyNewRotation(new v2f(plrot.Yaw, plrot.Pitch));
                break;
        }
    }
}
