using System.Linq;

[ChatCommand]
public class PrivateMessageCommand : IChatCommand
{
    public void Register()
    {
        var message = new Node()
        {
            Name = "message",
            Flags = Node.FlagsEnum.literal,
            Childrens = new System.Collections.Generic.List<Node>()
            {
                new Node()
                {
                    Name = "target",
                    Flags = Node.FlagsEnum.argument,
                    Parser = Node.Parsers.entity,
                    Properties = new Node.Parsers.EntityParser(Node.Parsers.EntityParser.State.Multiply),
                    Childrens = new System.Collections.Generic.List<Node>()
                    {
                        new Node()
                        {
                            Name = "message",
                            Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                            Parser = Node.Parsers.message,
                        }
                    }
                }
            }
        };
        Commands.Register(message, Execute);
        Commands.Register(new Node()
        {
            Name = "msg",
            Flags = Node.FlagsEnum.HasRedirect | Node.FlagsEnum.literal,
            RedirectNode = message
        }, Execute);
        Commands.Register(new Node()
        {
            Name = "tell",
            Flags = Node.FlagsEnum.HasRedirect | Node.FlagsEnum.literal,
            RedirectNode = message
        }, Execute);
        Commands.Register(new Node()
        {
            Name = "w",
            Flags = Node.FlagsEnum.HasRedirect | Node.FlagsEnum.literal,
            RedirectNode = message
        }, Execute);
    }
    public void Execute(RPGServer server, Player player, string[] args)
    {
        if (args.Length < 2) return;
        var target = player.rpgserver.FindByUsername(args[0]);
        var cfg = player.rpgserver.config.chat;
        player.Echo(
            player.PlayerUUID,
            Packets.Play.ChatMessage_clientbound.PositionType.chat,
            Chat.ColoredText(cfg.PMFormat
                .Replace("{playername}", player.data.username)
                .Replace("{selfusername}", target.data.username)
                .Replace("{message}", string.Join(" ", args.Skip(1)))));
        target.Echo(
            player.PlayerUUID,
            Packets.Play.ChatMessage_clientbound.PositionType.chat,
            Chat.ColoredText(cfg.PMFormat
                .Replace("{playername}", target.data.username)
                .Replace("{selfusername}", player.data.username)
                .Replace("{message}", string.Join(" ", args.Skip(1)))));
    }
}
