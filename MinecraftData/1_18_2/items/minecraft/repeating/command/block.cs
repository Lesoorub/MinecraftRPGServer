using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.repeating_command_block)]
    public class repeating_command_block : IBaseItem, ICanPlaceBlock
    {
        public short id => 443;
        public Rarity rarity => Rarity.epic;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.repeating_command_block";
        public ItemClasses @class => ItemClasses.CommandBlockItem;

        public BlockNameID block => BlockNameID.repeating_command_block;
    }
}
