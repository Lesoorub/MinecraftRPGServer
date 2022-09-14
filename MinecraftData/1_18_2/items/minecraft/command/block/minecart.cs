using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.command_block_minecart)]
    public class command_block_minecart : IBaseItem
    {
        public short id => 979;
        public Rarity rarity => Rarity.epic;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.command_block_minecart";
        public ItemClasses @class => ItemClasses.MinecartItem;
    }
}
