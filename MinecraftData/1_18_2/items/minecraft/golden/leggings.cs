using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.golden_leggings)]
    public class golden_leggings : IBaseItem, IHasCategory, IArmor
    {
        public short id => 756;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 105;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.golden_leggings";
        public ItemClasses @class => ItemClasses.ArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.legs;
        public byte defense => 3;
        public float toughness => 0f;
        public armor_material armor_material => armor_material.gold;
        public float knockback_resistance => 0f;
    }
}
