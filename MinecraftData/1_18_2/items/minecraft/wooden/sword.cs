using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.wooden_sword)]
    public class wooden_sword : IBaseItem, IHasCategory, ITool
    {
        public short id => 699;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 59;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.wooden_sword";
        public ItemClasses @class => ItemClasses.SwordItem;

        public byte category => 9;

        public short uses => 59;
        public float speed => 2f;
        public float attack_damage_bonus => 0f;
        public byte level => 0;
        public byte enchantment_value => 15;
        public float attack_damage => 3f;
    }
}
