using MineServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[PacketListener(0x0D, State.Play)]
public class OnInteractEntity : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var player = client as Player;
        var pack = packet as Packets.Play.InteractEntity;
        if (player == null || pack == null) return;

        if (pack.Type == Packets.Play.InteractEntity.InteractType.Attack &&
            player.world.Entities.TryGetValue(pack.EntityID, out var target) &&
            target is LivingEntity livingEntity_target)
        {
            player.Attack(livingEntity_target);
        }
    }
}