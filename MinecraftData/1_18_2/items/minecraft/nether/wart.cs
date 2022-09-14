using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.nether_wart)]
    public class nether_wart : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 862;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.nether_wart";
        public ItemClasses @class => ItemClasses.AliasedBlockItem;

        public byte category => 6;

        public BlockNameID block => BlockNameID.nether_wart;
    }
}
