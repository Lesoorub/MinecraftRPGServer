using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.chiseled_quartz_block)]
    public class chiseled_quartz_block : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 349;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.chiseled_quartz_block";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.chiseled_quartz_block;
    }
}
