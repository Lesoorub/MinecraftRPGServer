using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_block)]
    public class netherite_block : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 69;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => true;
        public string translation_key => "block.minecraft.netherite_block";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.netherite_block;
    }
}
