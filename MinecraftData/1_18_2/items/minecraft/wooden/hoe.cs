using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.wooden_hoe)]
    public class wooden_hoe : IBaseItem, IHasCategory, ITool
    {
        public short id => 703;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 59;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.wooden_hoe";
        public ItemClasses @class => ItemClasses.HoeItem;

        public byte category => 8;

        public short uses => 59;
        public float speed => 2f;
        public float attack_damage_bonus => 0f;
        public byte level => 0;
        public byte enchantment_value => 15;
        public float attack_damage => 0f;
    }
}
