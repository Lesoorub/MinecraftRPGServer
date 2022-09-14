using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.quartz)]
    public class quartz : IBaseItem, IHasCategory
    {
        public short id => 689;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.quartz";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
