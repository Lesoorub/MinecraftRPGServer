using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.brewing_stand)]
    public class brewing_stand : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 869;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.brewing_stand";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 10;

        public BlockNameID block => BlockNameID.brewing_stand;
    }
}
