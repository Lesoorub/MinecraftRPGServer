using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.snowball)]
    public class snowball : IBaseItem, IHasCategory
    {
        public short id => 780;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.snowball";
        public ItemClasses @class => ItemClasses.SnowballItem;

        public byte category => 6;
    }
}
