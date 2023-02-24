using MineServer;

[PacketListener(0x0D, State.Play)]
public class OnInteractEntity : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var pack = packet as Packets.Play.InteractEntity;
        if (player == null || pack == null) return;

        if (pack.Type == Packets.Play.InteractEntity.InteractType.Attack)
        {
            var target = player.world.EntityWorld.GetByEID(pack.EntityID);
            if (target is LivingEntity livingEntity_target)
                player.Attack(livingEntity_target);
        }
    }
}