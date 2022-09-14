using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.iron_pickaxe)]
    public class iron_pickaxe : IBaseItem, IHasCategory, ITool
    {
        public short id => 716;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 250;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.iron_pickaxe";
        public ItemClasses @class => ItemClasses.PickaxeItem;

        public byte category => 8;

        public short uses => 250;
        public float speed => 6f;
        public float attack_damage_bonus => 2f;
        public byte level => 2;
        public byte enchantment_value => 14;
        public float attack_damage => 3f;
    }
}
