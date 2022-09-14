using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.birch_door)]
    public class birch_door : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 634;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.birch_door";
        public ItemClasses @class => ItemClasses.TallBlockItem;

        public byte category => 2;

        public BlockNameID block => BlockNameID.birch_door;
    }
}
