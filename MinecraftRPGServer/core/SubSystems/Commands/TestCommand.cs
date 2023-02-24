using MinecraftRPGServer.core.SubSystems.Physics;

[ChatCommand]
public class TestCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("test", Execute);
    }
    RaycastEntityHit[] hits = new RaycastEntityHit[5];
    void Execute(RPGServer server, Player player, string[] args)
    {
        int hits_count;
        if ((hits_count = Raycast.AllEntitites(player.world, player.EyePosition, player.ForwardDir, 10, ref hits)) != 0)
        {
            for (int k = 0; k < hits_count; k++)
            {
                var hit = hits[k];
                if (hit.Entity.EntityID == player.EntityID)
                    continue;
                player.EchoIntoChatFromServer($"ID={hit.Entity.ID}, position={hit.Entity.Position}, distance={hit.distance}, point={hit.point}");
            }
        }
    }
}
