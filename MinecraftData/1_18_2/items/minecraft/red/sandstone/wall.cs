using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.red_sandstone_wall)]
    public class red_sandstone_wall : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 329;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.red_sandstone_wall";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.red_sandstone_wall;
    }
}
