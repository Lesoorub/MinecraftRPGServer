﻿using System.Collections.Generic;

namespace Inventory.Items
{
    public class Armor : RPGItem, IUsable
    {
        public virtual float Health { get; set; }

        public Armor(ItemNameID itemID) : base(itemID) { }

        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("minecraft:armor");
            return t;
        }
        public void Use(Player player)
        {
            Equip(player);
        }

        protected virtual void Equip(Player player)
        {

        }
        protected override void GetTooltip(ref List<Parameter> list)
        {
            base.GetTooltip(ref list);
            list.Add(new Parameter("Health", Health.ToString()));
        }
    }
}