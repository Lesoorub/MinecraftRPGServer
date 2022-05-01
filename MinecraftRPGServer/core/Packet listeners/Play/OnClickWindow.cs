﻿using MineServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[PacketListener(0x08, State.Play)]
public class OnClickWindow : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var clickWindow = packet as Packets.Play.ClickWindow;
        if (player == null || clickWindow == null) return;
        player.inventoryWindow.ClickWindow(clickWindow);//if (!player.inventoryWindow.ClickWindow(clickWindow))
        System.Threading.Thread.Sleep(100);
        player.SendInventory();
    }
}
