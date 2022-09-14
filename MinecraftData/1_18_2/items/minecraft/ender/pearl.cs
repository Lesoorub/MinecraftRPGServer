using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.ender_pearl)]
    public class ender_pearl : IBaseItem, IHasCategory
    {
        public short id => 858;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.ender_pearl";
        public ItemClasses @class => ItemClasses.EnderPearlItem;

        public byte category => 6;
    }
}
