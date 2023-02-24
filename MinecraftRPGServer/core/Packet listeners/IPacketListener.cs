using MineServer;

public interface IPacketListener
{
    RPGServer server { get; set; }
    void OnPacketRecieved(IClient client, IPacket packet);
}
