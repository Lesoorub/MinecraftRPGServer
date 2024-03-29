﻿using System.Security.Cryptography;
using MineServer;

public class ConnectedClient : IClient
{
    public State current_state = State.Handhaking;
    public NetworkProvider network { get; set; }
    public MineServer.ConnectionsServer server { get; set; }
    public int protocolVersion { get; set; }

    public byte[] VerifyToken { get; set; }
    public RSA rsa { get; set; }
    public byte[] SharedSecret { get; set; }
    public string username { get; set; }
    public ConnectedClient(NetworkProvider network, MinecraftCore server)
    {
        this.network = network;
        this.server = server;
        BeginRecievePackets();
    }

    public void BeginRecievePackets()
    {
        network.OnPacketRecieved += OnPacketRecievedPackets;
    }
    public void EndRecievePackets()
    {
        network.OnPacketRecieved -= OnPacketRecievedPackets;
    }
    public void OnPacketRecievedPackets(BytesBasedPacket packet)
    {
#if !DEBUG
        try
        {
#endif
        var minecraft_packets = MinecraftPacket.Parse(packet);
        foreach (var mpacket in minecraft_packets)
        {

            if (PackageRegistry.registered.TryGetValue(current_state, out var dict) &&
                dict.TryGetValue(mpacket.packet_id, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.OnPacketRecieved(this,
                        (IPacket)PacketListener.Parse(
                            mpacket,
                            PackageRegistry.BoundToServer[
                                MinecraftCore.IndexFromPacketIdAndState(
                                    mpacket.packet_id,
                                    current_state)]));
                }
            }
        }
#if !DEBUG
        }
        catch (System.Exception ex)
        {
            network.Disconnect();
        }
#endif
    }
}
