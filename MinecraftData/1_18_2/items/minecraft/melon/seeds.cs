using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.melon_seeds)]
    public class melon_seeds : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 852;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.melon_seeds";
        public ItemClasses @class => ItemClasses.AliasedBlockItem;

        public byte category => 6;

        public BlockNameID block => BlockNameID.melon_stem;
    }
}
