using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.raw_gold)]
    public class raw_gold : IBaseItem, IHasCategory
    {
        public short id => 695;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.raw_gold";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
