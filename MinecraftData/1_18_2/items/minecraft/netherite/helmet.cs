using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_helmet)]
    public class netherite_helmet : IBaseItem, IHasCategory, IArmor
    {
        public short id => 758;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 407;
        public bool is_fire_resistant => true;
        public string translation_key => "item.minecraft.netherite_helmet";
        public ItemClasses @class => ItemClasses.ArmorItem;

        public byte category => 9;

        public equipment_slot equipment_slot => equipment_slot.head;
        public byte defense => 3;
        public float toughness => 3f;
        public armor_material armor_material => armor_material.netherite;
        public float knockback_resistance => 0.1f;
    }
}
