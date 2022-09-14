using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.red_nether_brick_stairs)]
    public class red_nether_brick_stairs : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 560;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.red_nether_brick_stairs";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.red_nether_brick_stairs;
    }
}
