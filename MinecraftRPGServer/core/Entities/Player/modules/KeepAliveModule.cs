using Packets.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IModule
{
    void Init(Player player);
    void Tick();
}

public class KeepAliveModule : IModule
{
    public bool KeepAliveResponsed = true;
    public long SendedKeepAliveID;
    public DateTime SendedKeepAliveTime = DateTime.Now;
    public int ping;
    Player player;
    public void Init(Player player)
    {
        this.player = player;
    }

    public void Tick()
    {
        var keepAliveDelta = (DateTime.Now - SendedKeepAliveTime).TotalMilliseconds;
        if (keepAliveDelta >= PlayerSettings.KeepAliveDelay && KeepAliveResponsed)
            SendKeepAlive();
        if (keepAliveDelta >= PlayerSettings.MaxTimeout && KeepAliveResponsed)
        {
            player.network.Disconnect();
            return;
        }
    }
    public void OnKeepAliveRecieved(KeepAlive_serverbound packet)
    {
        ping = (int)(DateTime.Now - SendedKeepAliveTime).TotalMilliseconds;
        if (packet.KeepAliveID != SendedKeepAliveID)
        {
            player.network.Disconnect();
            return;
        }
        KeepAliveResponsed = true;
    }
    public void SendKeepAlive()
    {
        if (!KeepAliveResponsed) return;
        SendedKeepAliveTime = DateTime.Now;
        SendedKeepAliveID = RandomPlus.GetLong();
        KeepAliveResponsed = false;
        player.network.Send(new KeepAlive_clientbound()
        {
            KeepAliveID = SendedKeepAliveID,
        });
    }
}