using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.lime_concrete_powder)]
    public class lime_concrete_powder : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 505;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.lime_concrete_powder";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.lime_concrete_powder;
    }
}
