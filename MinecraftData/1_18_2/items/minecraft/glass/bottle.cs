using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.glass_bottle)]
    public class glass_bottle : IBaseItem, IHasCategory
    {
        public short id => 864;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.glass_bottle";
        public ItemClasses @class => ItemClasses.GlassBottleItem;

        public byte category => 10;
    }
}
