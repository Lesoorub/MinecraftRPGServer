using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.armor_stand)]
    public class armor_stand : IBaseItem, IHasCategory
    {
        public short id => 972;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.armor_stand";
        public ItemClasses @class => ItemClasses.ArmorStandItem;

        public byte category => 1;
    }
}
