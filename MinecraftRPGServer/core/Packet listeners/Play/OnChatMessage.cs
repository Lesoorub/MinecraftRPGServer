using MineServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[PacketListener(0x03, State.Play)]
public class OnChatMessage : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var msg = packet as Packets.Play.ChatMessage_serverbound;
        var player = client as Player;
        Console.WriteLine($"[{player.data.username}] {msg.Message}");
        if (msg.Message.StartsWith("/"))
        {
            string[] sp = msg.Message.Split(' ');
            Commands.Execute(sp[0], player, sp.Skip(1));
            return;
        }

        var server = client.server as RPGServer;

        string message = server.config.ChatFormat
            .Replace("{playername}", player.data.username);
        if (msg.Message.StartsWith("!"))//Global message
        {
            message = message
                .Replace("{channel}", server.config.GlobalChannelName)
                .Replace("{message}", msg.Message.Substring(1).Trim());
            if (message.Length > server.config.maxMessageSize)
                return;
            foreach (var pl in server.loginnedPlayers)
                pl.Value.Echo(player.PlayerUUID, Packets.Play.ChatMessage_clientbound.PositionType.chat, 
                    Chat.ColoredText(message));
        }
        else//Local message
        {
            message = message
                .Replace("{channel}", server.config.LocalChannelName)
                .Replace("{message}", msg.Message.Trim());
            if (message.Length > server.config.maxMessageSize)
                return;
            double sqrDistance = server.config.LocalRange * server.config.LocalRange;

            foreach (var pl in server.loginnedPlayers)
                if (v3f.SqrDistance(pl.Value.Position, player.Position) < sqrDistance)
                    pl.Value.Echo(player.PlayerUUID, Packets.Play.ChatMessage_clientbound.PositionType.chat,
                        Chat.ColoredText(message));
        }
    }
}
