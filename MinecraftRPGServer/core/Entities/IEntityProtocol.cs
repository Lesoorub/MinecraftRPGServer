using MineServer;

public interface IEntityProtocol
{
    /// <summary>
    /// Send spawn packet
    /// </summary>
    /// <param name="networks"></param>
    void SendSpawn(NetworkProvider[] networks);
}