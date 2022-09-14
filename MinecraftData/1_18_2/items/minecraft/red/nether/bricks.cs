using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.red_nether_bricks)]
    public class red_nether_bricks : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 448;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.red_nether_bricks";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.red_nether_bricks;
    }
}
