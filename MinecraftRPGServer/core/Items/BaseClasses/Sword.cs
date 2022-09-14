using System.Collections.Generic;

namespace Inventory.Items
{
    public abstract class Sword : RPGItem
    {
        public float MinDamage;
        public float MaxDamage;
        public virtual Sound AttackSound => new Sound(SoundID.entity_player_attack_sweep, Categories.PLAYERS);
        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("minecraft:sword");
            return t;
        }

        public override string Type => "Sword";
        public Sword(ItemNameID itemID) : base(itemID) { }
        protected override void GetTooltip(ref List<Parameter> list)
        {
            base.GetTooltip(ref list);
            list.Add(new Parameter("Damage", $"{MinDamage}-{MaxDamage}"));
        }
    }
}