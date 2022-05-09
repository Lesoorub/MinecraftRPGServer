using MineServer;
using System.Net;
using System.IO;

public class ConnectedClient : IClient
{
    public State current_state = State.Handhaking;
    public NetworkProvider network { get; set; }
    public MineServer.MineServer server { get; set; }
    public int protocolVersion { get; set; }
    public const bool compression = false;
    public const bool encryption = false;

    public ConnectedClient(NetworkProvider network, RPGServer server)
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

            if (RPGServer.registered.TryGetValue(current_state, out var dict) &&
                dict.TryGetValue(mpacket.packet_id, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.OnPacketRecieved(this,
                        (IPacket)PacketListener.Parse(
                            mpacket,
                            RPGServer.BoundToServer[
                                RPGServer.IndexFromPacketIdAndState(
                                    mpacket.packet_id,
                                    current_state)]));
                }
            }
        }
#if !DEBUG
        }
        catch (Exception ex)
        {
            network.Disconnect();
        }
#endif
    }
}
