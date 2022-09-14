using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_pickaxe)]
    public class netherite_pickaxe : IBaseItem, IHasCategory, ITool
    {
        public short id => 726;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 2031;
        public bool is_fire_resistant => true;
        public string translation_key => "item.minecraft.netherite_pickaxe";
        public ItemClasses @class => ItemClasses.PickaxeItem;

        public byte category => 8;

        public short uses => 2031;
        public float speed => 9f;
        public float attack_damage_bonus => 4f;
        public byte level => 4;
        public byte enchantment_value => 15;
        public float attack_damage => 5f;
    }
}
