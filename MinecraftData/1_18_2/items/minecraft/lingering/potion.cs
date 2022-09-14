using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.lingering_potion)]
    public class lingering_potion : IBaseItem, IHasCategory
    {
        public short id => 1008;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.lingering_potion";
        public ItemClasses @class => ItemClasses.LingeringPotionItem;

        public byte category => 10;
    }
}
