using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.waxed_oxidized_copper)]
    public class waxed_oxidized_copper : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 88;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.waxed_oxidized_copper";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.waxed_oxidized_copper;
    }
}
