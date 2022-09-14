using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.shears)]
    public class shears : IBaseItem, IHasCategory
    {
        public short id => 848;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 238;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.shears";
        public ItemClasses @class => ItemClasses.ShearsItem;

        public byte category => 8;
    }
}
