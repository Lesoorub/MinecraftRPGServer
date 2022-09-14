using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.written_book)]
    public class written_book : IBaseItem
    {
        public short id => 943;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.written_book";
        public ItemClasses @class => ItemClasses.WrittenBookItem;
    }
}
