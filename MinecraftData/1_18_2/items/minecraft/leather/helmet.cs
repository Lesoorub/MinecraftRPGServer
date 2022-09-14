using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.leather_helmet)]
    public class leather_helmet : IBaseItem, IHasCategory, IArmor
    {
        public short id => 738;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 55;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.leather_helmet";
        public ItemClasses @class => ItemClasses.DyeableArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.head;
        public byte defense => 1;
        public float toughness => 0f;
        public armor_material armor_material => armor_material.leather;
        public float knockback_resistance => 0f;
    }
}
