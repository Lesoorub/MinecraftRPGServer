using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.detector_rail)]
    public class detector_rail : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 658;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.detector_rail";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 3;

        public BlockNameID block => BlockNameID.detector_rail;
    }
}
