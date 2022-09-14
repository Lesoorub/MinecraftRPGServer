using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.dead_brain_coral_fan)]
    public class dead_brain_coral_fan : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 543;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.dead_brain_coral_fan";
        public ItemClasses @class => ItemClasses.WallStandingBlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.dead_brain_coral_fan;
    }
}
