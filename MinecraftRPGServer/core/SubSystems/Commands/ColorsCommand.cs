using System.Text;

[ChatCommand]
public class ColorsCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "colors",
            Flags = Node.FlagsEnum.IsExecutable | Node.FlagsEnum.literal,
            Childrens = new System.Collections.Generic.List<Node>()
            {
                new Node()
                {
                    Name = "text",
                    Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                    Parser = Node.Parsers.message,
                }
            }
        }, Execute);
    }
    void Execute(Player player, string[] args)
    {
        string msg = "example";
        if (args.Length != 0)
            msg = string.Join(" ", args);
        StringBuilder sb = new StringBuilder();
        foreach (var col in Chat.ColorIndexesArray)
            sb.Append(col + " -> &" + col + msg + "&r; ");
        player.EchoIntoChatFromServer(sb.ToString());
    }
}
