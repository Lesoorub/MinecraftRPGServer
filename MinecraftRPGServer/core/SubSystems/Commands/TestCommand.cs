using Packets.Play;
using MineServer;

[ChatCommand]
public class TestCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("test", Execute);
    }
    void Execute(Player player, string[] args)
    {

    }
}
