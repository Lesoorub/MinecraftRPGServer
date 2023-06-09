[ChatCommand]
public class SaveAllCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("save-all", Execute);
    }
    void Execute(MinecraftCore server, Player player, string[] args)
    {
        server.dispatcher.Invoke(() =>
        {
            string startMessage = "Saving started!";
            string endMessage = "Save ended!";
            Log(startMessage, player, server);
            foreach (var pair in server.worlds)
            {
                var world = pair.Value;
                world.Save(world.Path);
            }
            Log(endMessage, player, server);
        });
    }

    void Log(string text, Player player, MinecraftCore server)
    {
        server.logger.Write(text);
        if (player != null)
            player.EchoIntoChatFromServer(text);
    }
}
