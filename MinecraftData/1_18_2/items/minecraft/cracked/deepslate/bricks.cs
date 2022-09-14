using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.cracked_deepslate_bricks)]
    public class cracked_deepslate_bricks : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 288;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.cracked_deepslate_bricks";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.cracked_deepslate_bricks;
    }
}
