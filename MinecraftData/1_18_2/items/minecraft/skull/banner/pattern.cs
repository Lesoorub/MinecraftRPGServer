using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.skull_banner_pattern)]
    public class skull_banner_pattern : IBaseItem, IHasCategory
    {
        public short id => 1038;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.skull_banner_pattern";
        public ItemClasses @class => ItemClasses.BannerPatternItem;

        public byte category => 6;
    }
}
