using System;
using System.Linq;
using MinecraftData._1_18_2.items.minecraft;
using MineServer;
using Packets.Play;

[PacketListener(0x2E, State.Play)]
public class OnPlayerBlockPlacement : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var placePacket = packet as PlayerBlockPlacement;
        var player = client as Player;
        if (placePacket == null || player == null) return;

        player.OnPlayerTryPlaceBlock(
            placePacket.Location,
            placePacket.Face, 
            placePacket.Hand == PlayerBlockPlacement.HandType.MainHand,
            new v3f(placePacket.CursorPositionX, placePacket.CursorPositionY, placePacket.CursorPositionZ));
    }
}