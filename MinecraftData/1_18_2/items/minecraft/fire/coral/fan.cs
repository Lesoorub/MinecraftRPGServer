using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.fire_coral_fan)]
    public class fire_coral_fan : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 540;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.fire_coral_fan";
        public ItemClasses @class => ItemClasses.WallStandingBlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.fire_coral_fan;
    }
}
