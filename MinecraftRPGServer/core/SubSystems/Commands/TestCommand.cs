using Packets.Play;
using MineServer;
using MinecraftLightEngine;

[ChatCommand]
public class TestCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("test", Execute);
    }
    void Execute(RPGServer server, Player player, string[] args)
    {

    }
}
