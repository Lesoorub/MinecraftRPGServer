using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.warped_fungus_on_a_stick)]
    public class warped_fungus_on_a_stick : IBaseItem, IHasCategory
    {
        public short id => 668;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 100;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.warped_fungus_on_a_stick";
        public ItemClasses @class => ItemClasses.OnAStickItem;

        public byte category => 3;
    }
}
