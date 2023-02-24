using System;
using MineServer;
using Packets.Play;

[PacketListener(0x25, State.Play)]
public class OnHeldItemChange_serverbound : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var p = packet as HeldItemChange_serverbound;
        if (player == null) return;
        player.SelectedSlot = Math.Max(Math.Min((byte)p.Slot, (byte)8), (byte)0);
    }
}