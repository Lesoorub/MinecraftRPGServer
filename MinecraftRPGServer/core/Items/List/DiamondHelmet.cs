﻿using System;

namespace Items 
{
    [Item("minecraft:diamond_helmet")]
    public class DiamondHelmet : Helmet
    {
        public override SlotType allowedType => SlotType.Armor | SlotType.Helmet;
        public DiamondHelmet()
        {
            Name = "&4Diamond helmet";
            //ChatName = "{\"text\":\"Diamond helmet\",\"color\":\"red\",\"italic\":false}";
            //ChatName = new Chat()
            //{
            //    text = "Diamond helmet",
            //    color = Chat.ColorNames.red,
            //    italic = false,
            //};
            Lore = new string[]
            {
                "&aLore3",
                "&fLore4",
            };
            Health = 20;
            Damage = 1;
            Console.WriteLine(NBT._ToString);
        }
    }
}