using System.Linq;

[ChatCommand]
public class TeleportCommand : IChatCommand
{
    public void Register()
    {
        Node teleport = new Node()
        {
            Name = "teleport",
            Flags = Node.FlagsEnum.literal,
            Children = new System.Collections.Generic.List<Node>()
            {
                new Node()
                {
                    Name = "location",
                    Flags = Node.FlagsEnum.argument,
                    Parser = Node.Parsers.vec3,
                },
                new Node()
                {
                    Name = "targets",
                    Flags = Node.FlagsEnum.argument,
                    Parser = Node.Parsers.entity,
                    Properties = new Node.Parsers.EntityParser(Node.Parsers.EntityParser.State.Multiply),
                    Children = new System.Collections.Generic.List<Node>()
                    {
                        new Node()
                        {
                            Name = "destination",
                            Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                            Parser = Node.Parsers.entity,
                            Properties = new Node.Parsers.EntityParser(Node.Parsers.EntityParser.State.single),
                        }
                    }
                }
            }
        };
        Commands.Register(teleport, Execute);
        Commands.Register(new Node()
        {
            Name = "tp",
            Flags = Node.FlagsEnum.literal | Node.FlagsEnum.HasRedirect,
            RedirectNode = teleport
        }, Execute);
    }
    void Execute(Player player, string[] args)
    {
        switch (args.Length)
        {
            case 1://To player
                {
                    var destination_player = player.rpgserver.FindByUsername(args[0]);
                    if (destination_player != null)
                        player.TeleportTo(destination_player.Position);
                }
                break;
            case 2://Player one to player two
                {
                    var target_player = player.rpgserver.FindByUsername(args[0]);
                    var destination_player = player.rpgserver.FindByUsername(args[1]);
                    if (target_player != null && destination_player != null)
                        target_player.TeleportTo(destination_player.Position);
                }
                break;
            case 3://to coordinates
                {
                    bool GetCoordinate(string str, out bool isRelative, out float coordinate)
                    {
                        isRelative = false;
                        str = str.Trim();
                        if (str.Contains("~"))
                        {
                            str = str.Replace("~", "");
                            if (string.IsNullOrEmpty(str))
                                str = "0.0";
                            isRelative = true;
                        }
                        return float.TryParse(str.Replace(".", ","), out coordinate);
                    }
                    if (GetCoordinate(args[0], out var rx, out var x) &&
                        GetCoordinate(args[1], out var ry, out var y) &&
                        GetCoordinate(args[2], out var rz, out var z))
                        player.Position = new v3f(
                            x + (rx ? player.Position.x : 0),
                            y + (ry ? player.Position.y : 0),
                            z + (rz ? player.Position.z : 0));
                }
                break;
        }
    }
}