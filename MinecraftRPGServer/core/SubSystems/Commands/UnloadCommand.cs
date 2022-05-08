using System.Linq;

[ChatCommand]
public class UnloadCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "unload",
            Flags = Node.FlagsEnum.literal,
            Childrens = new System.Collections.Generic.List<Node>()
            {
                new Node()
                {
                    Name = "entities",
                    Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable
                }
            }
        }, Execute);
    }
    void Execute(Player player, string[] args)
    {
        if (args.Length >= 1 && args[0].Equals("entities"))
            player.entitiesController.UnloadEntities(player.view.entities.Select(x => x.Key));
    }
}
