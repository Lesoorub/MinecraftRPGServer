using System;
using System.Diagnostics;

[ChatCommand]
public class PerfomanceCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("perfomance", Execute);
    }
    void Execute(Player player, string[] args)
    {
        player.EchoIntoChatFromServer(
            $"&6Memory: See tab");
    }
}
