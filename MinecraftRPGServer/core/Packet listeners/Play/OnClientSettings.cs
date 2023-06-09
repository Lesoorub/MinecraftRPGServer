﻿using MineServer;
using Packets.Play;

[PacketListener(0x05, State.Play)]
public class OnClientSettings : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        if (player == null) return;
        var server = player.server as MinecraftCore;
        if (!player.isInit)
        {
            player.settings.UpdateBy(server, packet as ClientSettings);
            player.InvokeOnConnected();
            return;
        }
        player.settings.UpdateBy(server, packet as ClientSettings);
    }
}