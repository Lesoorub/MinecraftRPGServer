[ChatCommand]
public class SavePlayerCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("saveplayer", Execute);
    }
    void Execute(MinecraftCore server, Player player, string[] args)
    {
        try
        {
            player.data.Save(player);
            player.EchoIntoChatFromServer($"&2Игрок успешно сохранен!");
        }
        catch
        {
            player.EchoIntoChatFromServer($"&4Что-то пошло не так!");
        }
    }
}
