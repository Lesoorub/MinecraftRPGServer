using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.name_tag)]
    public class name_tag : IBaseItem, IHasCategory
    {
        public short id => 978;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.name_tag";
        public ItemClasses @class => ItemClasses.NameTagItem;

        public byte category => 8;
    }
}
