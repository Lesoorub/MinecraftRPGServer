using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.weathered_cut_copper_stairs)]
    public class weathered_cut_copper_stairs : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 79;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.weathered_cut_copper_stairs";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.weathered_cut_copper_stairs;
    }
}
