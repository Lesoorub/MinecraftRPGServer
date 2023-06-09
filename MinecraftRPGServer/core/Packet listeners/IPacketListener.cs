using MineServer;

public interface IPacketListener
{
    MinecraftCore server { get; set; }
    void OnPacketRecieved(IClient client, IPacket packet);
}
