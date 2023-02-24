using System.Collections.Generic;
using System.Linq;
using static Node;

[ChatCommand]
public class InfoCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "info",
            Flags = FlagsEnum.literal,
            Childrens = new List<Node>()
            {
                new Node()
                {
                    Name = "world",
                    Flags = FlagsEnum.literal | FlagsEnum.IsExecutable,
                },
                new Node()
                {
                    Name = "entities",
                    Flags = FlagsEnum.literal | FlagsEnum.IsExecutable,
                    Childrens = new List<Node>()
                    {
                        new Node()
                        {
                            Name = "current_chunk",
                            Flags = FlagsEnum.literal | FlagsEnum.IsExecutable
                        },
                        new Node()
                        {
                            Name = "in_radius",
                            Flags = FlagsEnum.literal,
                            Childrens = new List<Node>()
                            {
                                new Node()
                                {
                                    Name = "radius",
                                    Flags = FlagsEnum.argument| FlagsEnum.IsExecutable,
                                    Parser = Parsers.@float,
                                    Properties = new Parsers.FloatParser(Parsers.FloatParser.FlagsEnum.Min)
                                    {
                                        Min = 0
                                    }
                                }
                            }
                        },
                        new Node()
                        {
                            Name = "get",
                            Flags = FlagsEnum.literal,
                            Childrens = new List<Node>()
                            {
                                new Node()
                                {
                                    Name = "EID",
                                    Flags = FlagsEnum.argument | FlagsEnum.IsExecutable,
                                    Parser = Parsers.integer,
                                    Properties = new Parsers.IntegerParser(Parsers.IntegerParser.FlagsEnum.None)
                                }
                            }
                        }
                    }
                }
            }
        },
        Execute);
    }
    private void Execute(RPGServer server, Player player, string[] args)
    {
        if (args.Length == 0) return;
        if (args[0].Equals("world"))
        {
            player.EchoIntoChatFromServer($"World: {player.world.PublicName}");
            return;
        }

        string Vector3Format(v3f x) => $"({x.x:N1};{x.y:N1};{x.z:N1})".Replace(",", ".").Replace(";", ",");
        string Vector2Format(v2i x) => $"({x.x:N1};{x.y:N1})".Replace(",", ".").Replace(";", ",");
        string EntityFormat(Entity x) => $"&6EID=&7{x.EntityID}&6, ID=&7{x.ID}&6, Pos=&7{Vector3Format(x.Position)}&6, cpos=&7{Vector2Format(x.ChunkPos)}&6";

        if (args[0].Equals("entities"))
        {
            if (args.Length == 1)
            {
                player.EchoIntoChatFromServer($"&fFound {player.world.EntityWorld.entities.Count} entities in current world");
                return;
            }
            switch (args[1])
            {
                case "current_chunk":
                    {
                        var cpos = player.ChunkPos;
                        player.EchoIntoChatFromServer(
                            $"&fFor chunk [{cpos.x},{cpos.y}]\n" +
                            (player.world.EntityWorld.chunks.TryGetValue(cpos, out var dict)
                            ? $"  {dict.Count} entities: \n" +
                              string.Join("\n", dict.Values.Select(x => "   " + EntityFormat(x)))
                            : "Empty") +
                            $""
                            );
                    }
                    break;
                case "in_radius":
                    {
                        if (args.Length >= 3 && float.TryParse(args[2], out var radius))
                        {
                            var ents = player.world.EntityWorld.GetEntitiesInCircle(player.Position, radius);
                            player.EchoIntoChatFromServer(
                                $"&6In radius found {ents.Count} entities:\n" +
                                string.Join("\n", ents.Select(x => "   " + EntityFormat(x))));
                        }
                    }
                    break;
                case "get":
                    {
                        if (args.Length >= 3 && int.TryParse(args[2], out var eid))
                        {
                            var ent = player.world.EntityWorld.GetByEID(eid);
                            if (ent != null)
                                player.EchoIntoChatFromServer(EntityFormat(ent));
                            else
                                player.EchoIntoChatFromServer($"&6Entity with eid={eid} not found");
                        }
                    }
                    break;
            }
        }
    }
}
