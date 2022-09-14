using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.writable_book)]
    public class writable_book : IBaseItem, IHasCategory
    {
        public short id => 942;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.writable_book";
        public ItemClasses @class => ItemClasses.WritableBookItem;

        public byte category => 6;
    }
}
