using System.Threading.Tasks;
using System.Linq;
using Packets.Play;
using MineServer;

[ChatCommand]
public class TestCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("test",
        (player, args) =>
        {
            player.SendDestroyEntities(player.view.entities.Select(x => x.Key));
        });
    }
}
