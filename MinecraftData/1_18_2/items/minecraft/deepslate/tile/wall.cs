using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.deepslate_tile_wall)]
    public class deepslate_tile_wall : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 345;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.deepslate_tile_wall";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.deepslate_tile_wall;
    }
}
