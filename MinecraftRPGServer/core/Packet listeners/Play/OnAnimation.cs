using MineServer;
using Packets.Play;

[PacketListener(0x2C, State.Play)]
public class OnAnimation : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var pack = packet as Animation_serverbound;
        if (player == null) return;
        player.PlayAnimation(pack.Hand == 0 ? 
            EntityAnimation_clientbound.AnimationType.SwingMainArm : 
            EntityAnimation_clientbound.AnimationType.SwingOffhand);

        var sound = new Sound(807, Categories.PLAYERS);//entity.player.attack.weak
        if (player.SelectedItem is Inventory.Items.Sword sword)
            sound = sword.AttackSound;
        player.PlayEntitySound(sound);
    }
}