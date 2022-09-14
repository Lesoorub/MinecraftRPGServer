using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_chestplate)]
    public class netherite_chestplate : IBaseItem, IHasCategory, IArmor
    {
        public short id => 759;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 592;
        public bool is_fire_resistant => true;
        public string translation_key => "item.minecraft.netherite_chestplate";
        public ItemClasses @class => ItemClasses.ArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.chest;
        public byte defense => 8;
        public float toughness => 3f;
        public armor_material armor_material => armor_material.netherite;
        public float knockback_resistance => 0.1f;
    }
}
