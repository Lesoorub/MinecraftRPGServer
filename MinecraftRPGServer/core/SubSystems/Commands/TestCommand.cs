using System.Threading.Tasks;
using Packets.Play;
using System;
using MineServer;

[ChatCommand]
public class TestCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("test",
        (player, args) =>
        {

        });
    }
}
