using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[ChatCommand]
public class CreateCommand : IChatCommand
{
    public void Register()
    {
        var quality = new Node()
        {
            Name = "quality",
            Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
            Childrens = Enum.GetNames(typeof(Inventory.Items.Quality))
            .Select(quality_name =>
            new Node()
            {
                Name = quality_name,
                Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable
            }).ToList()
        };
        var rarity = new Node()
        {
            Name = "rarity",
            Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
            Childrens = Enum.GetNames(typeof(Inventory.Items.Rarity))
            .Select(rarity_name =>
            new Node()
            {
                Name = rarity_name,
                Flags = Node.FlagsEnum.HasRedirect | Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
                RedirectNode = quality
            }).ToList()
        };
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
                },
                new Node()
                {
                    Name = "item",
                    Flags = Node.FlagsEnum.literal,
                    Childrens = new List<Node>()
                    {
                        new Node()
                        {
                            Name = "NameID",
                            Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                            Parser = Node.Parsers.item_stack,
                            Childrens = new List<Node>()
                            {
                                new Node()
                                {
                                    Name = "count",
                                    Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                                    Parser = Node.Parsers.integer,
                                    Properties = new Node.Parsers.IntegerParser(Node.Parsers.IntegerParser.FlagsEnum.Min)
                                    {
                                        Min = 1,
                                    }
                                }
                            }
                        }
                    }
                },
                new Node()
                {
                    Name = "rpg_item",
                    Flags = Node.FlagsEnum.literal,
                    Childrens = Inventory.Items.RPGItem.rpgItems
                    .Select(rpgItemPair =>
                    new Node()
                    {
                        Name = rpgItemPair.Key,
                        Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable | Node.FlagsEnum.HasRedirect,
                        RedirectNode = rarity,
                    }).ToList()
                }
            }
        },
        Execute);
    }
    private void Execute(MinecraftCore server, Player player, string[] args)
    {
        if (args.Length < 2) return;
        if (args[0] == "entity")
            SpawnEntity(player, args.Skip(1).ToArray());
        else if (args[0] == "item")
            CreateItem(player, args.Skip(1).ToArray());
        else if (args[0] == "rpg_item")
            CreateRPGItem(player, args.Skip(1).ToArray());
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
    private void CreateItem(Player player, string[] args)
    {
        string nameid;
        byte count = 1;
        switch (args.Length)
        {
            case 1:
                nameid = args[0];
                break;
            case 2:
                if (int.TryParse(args[1], out int _count) && _count <= Inventory.Item.DefaultMaxCount && _count > 0)
                {
                    nameid = args[0];
                    count = (byte)_count;
                    break;
                }
                return;
            default:
                return;
        }
        if (string.IsNullOrEmpty(nameid)) return;
        try
        {
            if (Inventory.Item.GetItemID(nameid.Replace("minecraft:", ""), out var ItemID))
                GiveItem(player, Inventory.Item.Create(ItemID, count));
        }
        catch (Exception ex)
        {
            player.EchoIntoChatFromServer(ex.Message);
        }
    }
    static readonly string[] RarityNames = Enum.GetNames(typeof(Inventory.Items.Rarity));
    static readonly string[] QualityNames = Enum.GetNames(typeof(Inventory.Items.Quality));
    private void CreateRPGItem(Player player, string[] args)
    {
        if (args.Length == 0 || string.IsNullOrEmpty(args[0])) return;
        string nameid = args[0].Replace("minecraft:", "");
        if (Inventory.Items.RPGItem.Has(nameid))
        {
            int rarity = -1;
            int quality = -1;

            if (args.Length >= 2)
                rarity = Array.IndexOf(RarityNames, args[1]);
            if (args.Length >= 3)
                quality = Array.IndexOf(QualityNames, args[2]);

            if (rarity == -1)
                rarity = (int)Inventory.Items.Rarity.Trash;
            if (quality == -1)
                quality = (int)Inventory.Items.Quality.Normal;

            GiveItem(player, Inventory.Items.RPGItem.Create(
                nameid,
                (Inventory.Items.Rarity)rarity,
                (Inventory.Items.Quality)quality));
        }
        else
        {
            player.EchoIntoChatFromServer($"&4RPGItem not found");
        }
    }

    private void GiveItem(Player player, Inventory.Item item)
    {
        if (item == null) return;
        if (player.inventory.AddItem(ref item))
            player.api.SendInventory();
        else
            player.EchoIntoChatFromServer("&6Not enought space");

        if (item != null && item.Present)
            Entities.Item.Spawn(player.world, item, player.Position);
    }
}
