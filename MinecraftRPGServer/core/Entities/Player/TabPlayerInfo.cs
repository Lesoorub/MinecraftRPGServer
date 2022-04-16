using System.Linq;
using System.Threading;
using MineServer;
using Packets.Play;

public class TabPlayerInfo
{
    public const int UpdateDelayMs = 5000;
    public RPGServer server;
    public Thread thread;
    public TabPlayerInfo(RPGServer server)
    {
        this.server = server;
        server.OnLoginIn += Server_OnLoginIn;
        server.OnLogOut += Server_OnLogOut;

        thread = new Thread(() =>
        {
            while (server.isStarted)
            {
                Tick();
                Thread.Sleep(UpdateDelayMs);
            }
        });
    }

    public void SendPlayers(NetworkProvider network)
    {
        //Отправить игроку информацию о всех подключенных игроках
        network.Send(new PlayerInfo()
        {
            Action = PlayerInfo.Player.Add.ActionID,
            players = server.loginnedPlayers
            .Select(x => new PlayerInfo.Player()
            {
                uuid = x.Value.PlayerUUID,
                some = new PlayerInfo.Player.Add()
                {
                    Name = x.Value.data.username,
                    Gamemode = new VarInt((int)x.Value.Gamemode),
                    Ping = x.Value.keepAlive.ping,
                }
            }).ToArray()
        });
    }
    private void Server_OnLoginIn(Player player)
    {
        //Отправить всем подключенным игрокам информацию о подключении 
        foreach (var pl in server.loginnedPlayers
            .Where(x => !x.Value.Equals(player) && x.Value.isInit))
        {
            pl.Value.network.Send(new PlayerInfo()
            {
                Action = PlayerInfo.Player.Add.ActionID,
                players = new PlayerInfo.Player[] 
                { 
                    new PlayerInfo.Player()
                    {
                        uuid = player.PlayerUUID,
                        some = new PlayerInfo.Player.Add()
                        {
                            Name = player.data.username,
                            Gamemode = new VarInt((int)player.Gamemode),
                            Ping = player.keepAlive.ping,
                        }
                    }
                }
            });
        }
    }

    private void Server_OnLogOut(Player player)
    {
        //Отправить всем подключенным игрокам информацию о отключении игрока 
        foreach (var pl in server.loginnedPlayers
            .Where(x => !x.Value.Equals(player) && x.Value.isInit))
            pl.Value.network.Send(new PlayerInfo()
            {
                Action = PlayerInfo.Player.RemovePlayer.ActionID,
                players = server.loginnedPlayers.Select(x => new PlayerInfo.Player()
                {
                    uuid = player.PlayerUUID,
                    some = new PlayerInfo.Player.RemovePlayer()
                }).ToArray()
            });
    }

    public void Tick()
    {
        //update ping and gamemode
        foreach (var pl in server.loginnedPlayers.Where(x => x.Value.isInit))
        {
            pl.Value.network.Send(new PlayerInfo()
            {
                Action = PlayerInfo.Player.UpdateLatency.ActionID,
                players = server.loginnedPlayers.Select(x => new PlayerInfo.Player()
                {
                    uuid = x.Value.PlayerUUID,
                    some = new PlayerInfo.Player.UpdateLatency()
                    {
                        Ping = x.Value.keepAlive.ping
                    }
                }).ToArray()
            });
            pl.Value.network.Send(new PlayerInfo()
            {
                Action = PlayerInfo.Player.UpdateGamemode.ActionID,
                players = server.loginnedPlayers.Select(x => new PlayerInfo.Player()
                {
                    uuid = x.Value.PlayerUUID,
                    some = new PlayerInfo.Player.UpdateGamemode()
                    {
                        Gamemode = new VarInt((int)x.Value.Gamemode)
                    }
                }).ToArray()
            });
        }
    }
}