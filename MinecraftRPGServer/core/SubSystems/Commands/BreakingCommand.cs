using Packets.Play;

[ChatCommand]
public class BreakingCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("breaking",
        (player, args) =>
        {
            player.rpgserver.config.AllowBreakBlocks = !player.rpgserver.config.AllowBreakBlocks;
            player.Echo(
                System.Guid.Empty, 
                ChatMessage_clientbound.PositionType.system_message, 
                Chat.ColoredText($"&6Braking now is {(player.rpgserver.config.AllowBreakBlocks ? "&aenabled" : "&cdisabled")}"));
        });
    }
}
