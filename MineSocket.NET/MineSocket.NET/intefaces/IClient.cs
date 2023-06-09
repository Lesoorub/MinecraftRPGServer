namespace MineServer
{
    public interface IClient
    {
        NetworkProvider network { get; set; }
        ConnectionsServer server { get; set; }
        int protocolVersion { get; set; }
    }
}
