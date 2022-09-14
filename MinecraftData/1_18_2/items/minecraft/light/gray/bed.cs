using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.light_gray_bed)]
    public class light_gray_bed : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 838;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.light_gray_bed";
        public ItemClasses @class => ItemClasses.BedItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.light_gray_bed;
    }
}
