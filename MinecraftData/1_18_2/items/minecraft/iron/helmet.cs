using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.iron_helmet)]
    public class iron_helmet : IBaseItem, IHasCategory, IArmor
    {
        public short id => 746;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 165;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.iron_helmet";
        public ItemClasses @class => ItemClasses.ArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.head;
        public byte defense => 2;
        public float toughness => 0f;
        public armor_material armor_material => armor_material.iron;
        public float knockback_resistance => 0f;
    }
}
