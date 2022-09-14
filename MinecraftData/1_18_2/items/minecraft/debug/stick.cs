using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.debug_stick)]
    public class debug_stick : IBaseItem
    {
        public short id => 1014;
        public Rarity rarity => Rarity.epic;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.debug_stick";
        public ItemClasses @class => ItemClasses.DebugStickItem;
    }
}
