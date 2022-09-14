using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.dried_kelp_block)]
    public class dried_kelp_block : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 790;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.dried_kelp_block";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.dried_kelp_block;
    }
}
