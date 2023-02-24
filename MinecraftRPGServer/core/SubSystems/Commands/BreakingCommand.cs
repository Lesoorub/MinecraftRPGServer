using Packets.Play;

[ChatCommand]
public class BreakingCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("breaking",
        (server, player, args) =>
        {
            var cfg = player.rpgserver.config.world;
            cfg.AllowBreakBlocks = !cfg.AllowBreakBlocks;
            player.Echo(
                System.Guid.Empty,
                ChatMessage_clientbound.PositionType.system_message,
                Chat.ColoredText($"&6Braking now is {(cfg.AllowBreakBlocks ? "&aenabled" : "&cdisabled")}"));
        });
    }
}
