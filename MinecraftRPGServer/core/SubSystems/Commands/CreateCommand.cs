using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

[ChatCommand]
public class CreateCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "create",
            Flags = Node.FlagsEnum.literal,
            Childrens = new List<Node>()
            {
                new Node()
                {
                    Name = "entity",
                    Flags = Node.FlagsEnum.literal,
                    Childrens = Entity.EntityList
                        .Select(x =>
                        {
                            var attr = x.Value.GetCustomAttribute<EntityAttribute>();
                            if (attr.customCmd == null)
                                return new Node()
                                {
                                    Name = x.Key,
                                    Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
                                };
                            else return attr.customCmd.node; 
                        }).ToList()
                }
            }
        },
        Execute);
    }
    private void Execute(Player plater, string[] args)
    {
        if (args.Length >= 2 && args[0] == "entity")
            SpawnEntity(plater, args.Skip(1).ToArray());

    }
    private void SpawnEntity(Player player, string[] args)
    {
        if (Entity.EntityList.TryGetValue(args[0], out var ent_type))
        {
            var entity = (Entity)Activator.CreateInstance(ent_type, player.world);
            entity.Position = player.Position;
            entity.Rotation = player.Rotation;
            var attr = ent_type.GetCustomAttribute<EntityAttribute>();
            if (attr.customCmd != default)
                attr.customCmd.onExecute(entity, args.Skip(1).ToArray());
        }
    }
}
