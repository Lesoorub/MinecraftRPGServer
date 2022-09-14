using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.warped_button)]
    public class warped_button : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 618;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.warped_button";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 2;

        public BlockNameID block => BlockNameID.warped_button;
    }
}
