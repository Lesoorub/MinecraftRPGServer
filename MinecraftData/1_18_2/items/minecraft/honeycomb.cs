using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.honeycomb)]
    public class honeycomb : IBaseItem, IHasCategory
    {
        public short id => 1059;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.honeycomb";
        public ItemClasses @class => ItemClasses.HoneycombItem;

        public byte category => 6;
    }
}
