using System.Linq;

[ChatCommand]
public class UnloadCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "reload",
            Flags = Node.FlagsEnum.literal,
            Childrens = new System.Collections.Generic.List<Node>()
            {
                new Node()
                {
                    Name = "entities",
                    Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable
                },
                new Node()
                {
                    Name = "chunks",
                    Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable
                },
            }
        }, Execute);
    }
    void Execute(RPGServer server, Player player, string[] args)
    {
        if (args.Length >= 1)
        {
            if (args[0].Equals("entities"))
            {
                player.entitiesController.UnloadEntities(player.view.entities.Select(x => x.Key));
                player.EchoIntoChatFromServer("Entities reloaded");
            }
            else if (args[0].Equals("chunks"))
            {
                player.worldController.UnloadChunks();
                player.worldController.SendWorld();
                player.api.SendPlayerPositionAndLook();
                player.EchoIntoChatFromServer("Chunks reloaded");
            }
        }
    }
}