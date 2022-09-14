using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.dead_tube_coral_block)]
    public class dead_tube_coral_block : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 517;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.dead_tube_coral_block";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.dead_tube_coral_block;
    }
}
