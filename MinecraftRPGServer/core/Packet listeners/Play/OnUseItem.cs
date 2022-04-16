using MineServer;
using Packets.Play;
using System.Threading.Tasks;

[PacketListener(0x2F, State.Play)]
public class OnUseItem : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var pack = packet as UseItem;
        if (player == null) return; 
        (player.SelectedItem as IUsable)?.Use(player);
        player.PlayAnimation(pack.Hand == 0 ? 
            EntityAnimation_clientbound.AnimationType.SwingMainArm : 
            EntityAnimation_clientbound.AnimationType.SwingOffhand);
    }
}
