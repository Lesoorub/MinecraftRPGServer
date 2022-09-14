[ChatCommand]
public class BornCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "born",
            Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
            Childrens = new System.Collections.Generic.List<Node>()
            {
                new Node()
                {
                    Name = "player",
                    Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                    Parser = Node.Parsers.entity,
                    Properties = new Node.Parsers.EntityParser(Node.Parsers.EntityParser.State.single)
                }
            }
        },
        Execute);
    }
    void Execute(RPGServer server, Player player, string[] args)
    {
        Player target = player;
        switch (args.Length)
        {
            case 0:
                target = player;
                break;
            case 1:
                target = player.rpgserver.FindByUsername(args[0]);
                break;
        }
        if (target != null)
        {
            target.SetFire(!((EntityMetadata.EntityStatus)target.meta["entityStatus"]).HasFlag(EntityMetadata.EntityStatus.IsOnFire));
            player.EchoIntoChatFromServer($"&2Игрок{(target != player ? $" &f{target.data.username}&2" : "")} успешно подожжен! Да пусть горит он адским пламенем!");
        }
        else
        {
            player.EchoIntoChatFromServer($"&4Игрок не найден");
        }
    }
}
