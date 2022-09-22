namespace MineServer
{
    public interface IClient
    {
        NetworkProvider network { get; set; }
        MineServer server { get; set; }
        int protocolVersion { get; set; }
    }
}
