using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.arrow)]
    public class arrow : IBaseItem, IHasCategory
    {
        public short id => 683;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.arrow";
        public ItemClasses @class => ItemClasses.ArrowItem;

        public byte category => 9;
    }
}
