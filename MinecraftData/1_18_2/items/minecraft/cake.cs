using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.cake)]
    public class cake : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 829;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.cake";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 7;

        public BlockNameID block => BlockNameID.cake;
    }
}
