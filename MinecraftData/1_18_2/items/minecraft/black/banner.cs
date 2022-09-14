using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.black_banner)]
    public class black_banner : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 997;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.black_banner";
        public ItemClasses @class => ItemClasses.BannerItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.black_banner;
    }
}
