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
        var server = client.server as RPGServer;
        var con_cl = client as ConnectedClient;
        if (server.LoginIn(client, startlogin.name, out var player))
        {
            player.network.Send(new LoginSuccess()
            {
                username = player.data.username
            });
            player.network.Send(new JoinGame()
            {
                EntityID = player.EntityID,
                isHardcore = false,
                Gamemode = (byte)player.Gamemode,
                PreviousGamemode = -1,
                DimensionsNames = new string[] { "minecraft:overworld" },
                DimensionCodec = SupportedProtocol.allprotocols[con_cl.protocolVersion].DimensionCodec,
                Dimension = SupportedProtocol.allprotocols[con_cl.protocolVersion].Dimension,
                DimensionName = player.world.publicName,
                HashedSeed = 0,
                MaxPlayers = server.maxPlayers,
                ViewDistance = server.config.MaxViewDistance,
                ReducedDebugInfo = false,
                EnableRespawnScreen = false,
                IsDebug = false,
                IsFlat = true
            });
        }
        else
        {
            client.network.Send(new Disconnect()
            {
                reason = "Already connected"
            });
            client.network.Disconnect();
        }
    }
}
