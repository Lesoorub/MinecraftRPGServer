using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.air)]
    public class air : IBaseItem
    {
        public short id => 0;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.air";
        public ItemClasses @class => ItemClasses.AirBlockItem;
    }
}
