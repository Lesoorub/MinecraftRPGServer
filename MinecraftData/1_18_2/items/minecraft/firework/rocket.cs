using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.firework_rocket)]
    public class firework_rocket : IBaseItem, IHasCategory
    {
        public short id => 961;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.firework_rocket";
        public ItemClasses @class => ItemClasses.FireworkRocketItem;

        public byte category => 6;
    }
}
