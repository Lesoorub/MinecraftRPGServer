using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.glow_item_frame)]
    public class glow_item_frame : IBaseItem, IHasCategory
    {
        public short id => 945;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.glow_item_frame";
        public ItemClasses @class => ItemClasses.ItemFrameItem;

        public byte category => 1;
    }
}
