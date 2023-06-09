[ChatCommand]
public class TestCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("test", Execute);
    }
    void Execute(MinecraftCore server, Player player, string[] args)
    {

    }
}
