using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.tipped_arrow)]
    public class tipped_arrow : IBaseItem, IHasCategory
    {
        public short id => 1007;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.tipped_arrow";
        public ItemClasses @class => ItemClasses.TippedArrowItem;

        public byte category => 9;
    }
}
