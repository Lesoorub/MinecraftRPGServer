using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.bundle)]
    public class bundle : IBaseItem
    {
        public short id => 796;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.bundle";
        public ItemClasses @class => ItemClasses.BundleItem;
    }
}
