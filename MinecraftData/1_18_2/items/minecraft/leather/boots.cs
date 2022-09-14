using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.leather_boots)]
    public class leather_boots : IBaseItem, IHasCategory, IArmor
    {
        public short id => 741;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 65;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.leather_boots";
        public ItemClasses @class => ItemClasses.DyeableArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.feet;
        public byte defense => 1;
        public float toughness => 0f;
        public armor_material armor_material => armor_material.leather;
        public float knockback_resistance => 0f;
    }
}
