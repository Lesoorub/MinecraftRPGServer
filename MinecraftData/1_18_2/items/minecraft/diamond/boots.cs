using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.diamond_boots)]
    public class diamond_boots : IBaseItem, IHasCategory, IArmor
    {
        public short id => 753;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 429;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.diamond_boots";
        public ItemClasses @class => ItemClasses.ArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.feet;
        public byte defense => 3;
        public float toughness => 2f;
        public armor_material armor_material => armor_material.diamond;
        public float knockback_resistance => 0f;
    }
}
