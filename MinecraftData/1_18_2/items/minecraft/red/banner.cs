using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.red_banner)]
    public class red_banner : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 996;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.red_banner";
        public ItemClasses @class => ItemClasses.BannerItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.red_banner;
    }
}
