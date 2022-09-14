using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.fire_charge)]
    public class fire_charge : IBaseItem, IHasCategory
    {
        public short id => 941;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.fire_charge";
        public ItemClasses @class => ItemClasses.FireChargeItem;

        public byte category => 6;
    }
}
