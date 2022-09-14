using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.diamond_chestplate)]
    public class diamond_chestplate : IBaseItem, IHasCategory, IArmor
    {
        public short id => 751;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 528;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.diamond_chestplate";
        public ItemClasses @class => ItemClasses.ArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.chest;
        public byte defense => 8;
        public float toughness => 2f;
        public armor_material armor_material => armor_material.diamond;
        public float knockback_resistance => 0f;
    }
}
