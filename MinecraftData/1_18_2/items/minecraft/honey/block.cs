using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.honey_block)]
    public class honey_block : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 593;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.honey_block";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 2;

        public BlockNameID block => BlockNameID.honey_block;
    }
}
