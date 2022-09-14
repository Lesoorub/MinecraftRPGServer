using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.pink_stained_glass_pane)]
    public class pink_stained_glass_pane : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 422;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.pink_stained_glass_pane";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.pink_stained_glass_pane;
    }
}
