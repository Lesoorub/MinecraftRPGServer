[ChatCommand]
public class PerfomanceCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("perfomance", Execute);
    }
    void Execute(MinecraftCore server, Player player, string[] args)
    {
        player.EchoIntoChatFromServer(
            $"&6Memory: See tab");
    }
}
