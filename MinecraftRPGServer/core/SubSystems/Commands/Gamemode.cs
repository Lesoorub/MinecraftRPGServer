using System.Collections.Generic;

[ChatCommand]
public class Gamemode : IChatCommand
{
    public void Register()
    {
        Commands.Register(
        new Node()
        {
            Flags = Node.FlagsEnum.literal,
            Name = "gamemode",
            Childrens = new List<Node>()
            {
                    new Node()
                    {
                        Flags = Node.FlagsEnum.IsExecutable | Node.FlagsEnum.argument,
                        Name = "mode",
                        Parser = Node.Parsers.integer,
                        Properties = new Node.Parsers.IntegerParser(Node.Parsers.IntegerParser.FlagsEnum.Min | Node.Parsers.IntegerParser.FlagsEnum.Max)
                        {
                            Min = 0,
                            Max = 3
                        }
                    },
                    new Node()
                    {
                        Flags = Node.FlagsEnum.IsExecutable | Node.FlagsEnum.literal,
                        Name = "survival",
                    },
                    new Node()
                    {
                        Flags = Node.FlagsEnum.IsExecutable | Node.FlagsEnum.literal,
                        Name = "creative",
                    },
                    new Node()
                    {
                        Flags = Node.FlagsEnum.IsExecutable | Node.FlagsEnum.literal,
                        Name = "adventure",
                    },
                    new Node()
                    {
                        Flags = Node.FlagsEnum.IsExecutable | Node.FlagsEnum.literal,
                        Name = "spectator",
                    }
            }
        },
        Execute);
    }
    private void Execute(RPGServer server, Player player, string[] args)
    {
        if (args.Length == 1)
        {
            GamemodeType newgm = player.Gamemode;
            if (byte.TryParse(args[0], out var gamemode))
                newgm = (GamemodeType)gamemode;
            else
            {
                if (args[0] == "survival")
                    newgm = GamemodeType.Survival;
                if (args[0] == "creative")
                    newgm = GamemodeType.Creative;
                if (args[0] == "adventure")
                    newgm = GamemodeType.Adventure;
                if (args[0] == "spectator")
                    newgm = GamemodeType.Spectator;
            }
            if (newgm == player.Gamemode)
                return;
            player.Gamemode = newgm;
            switch (player.Gamemode)
            {
                case GamemodeType.Survival:
                    player.Echo(default, Packets.Play.ChatMessage_clientbound.PositionType.chat,
                        Chat.ColoredText("&6Change gamemode to Survival"));
                    break;
                case GamemodeType.Creative:
                    player.Echo(default, Packets.Play.ChatMessage_clientbound.PositionType.chat,
                        Chat.ColoredText("&6Change gamemode to Creative"));
                    break;
                case GamemodeType.Adventure:
                    player.Echo(default, Packets.Play.ChatMessage_clientbound.PositionType.chat,
                        Chat.ColoredText("&6Change gamemode to Adventure"));
                    break;
                case GamemodeType.Spectator:
                    player.Echo(default, Packets.Play.ChatMessage_clientbound.PositionType.chat,
                        Chat.ColoredText("&6Change gamemode to Spectator"));
                    break;
            }
        }
    }
}
