using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_ingot)]
    public class netherite_ingot : IBaseItem, IHasCategory
    {
        public short id => 697;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => true;
        public string translation_key => "item.minecraft.netherite_ingot";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
