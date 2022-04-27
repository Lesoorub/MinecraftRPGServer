﻿using System;

[ChatCommand]
public class GiveCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "give",
            Flags = Node.FlagsEnum.literal,
            Childrens = new System.Collections.Generic.List<Node>()
            {
                new Node()
                {
                    Name = "NameID",
                    Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                    Parser = Node.Parsers.item_stack,
                    Childrens = new System.Collections.Generic.List<Node>()
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
        (player, args) =>
        {
            string nameid = "";
            byte count = 1;
            switch (args.Length)
            {
                case 1:
                    nameid = args[0];
                    break;
                case 2:
                    if (int.TryParse(args[1], out int _count) && _count <= 64 && _count > 0)
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
                if (!nameid.StartsWith("minecraft:"))
                    nameid = "minecraft:" + nameid;
                if (player.inventory.AddItem(Item.Create(nameid, count), out var rest_item))
                    player.SendInventory();
                else
                {
                    player.EchoIntoChatFromServer("Not enought space");
                }
            }
            catch (Exception ex)
            {
                player.EchoIntoChatFromServer(ex.Message);
            }
        });
    }
}
