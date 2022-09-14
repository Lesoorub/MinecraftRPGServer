using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.enchanted_book)]
    public class enchanted_book : IBaseItem
    {
        public short id => 963;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.enchanted_book";
        public ItemClasses @class => ItemClasses.EnchantedBookItem;
    }
}
