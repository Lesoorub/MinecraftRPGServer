using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_boots)]
    public class netherite_boots : IBaseItem, IHasCategory, IArmor
    {
        public short id => 761;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 481;
        public bool is_fire_resistant => true;
        public string translation_key => "item.minecraft.netherite_boots";
        public ItemClasses @class => ItemClasses.ArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.feet;
        public byte defense => 3;
        public float toughness => 3f;
        public armor_material armor_material => armor_material.netherite;
        public float knockback_resistance => 0.1f;
    }
}
