using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.diamond_sword)]
    public class diamond_sword : IBaseItem, IHasCategory, ITool
    {
        public short id => 719;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 1561;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.diamond_sword";
        public ItemClasses @class => ItemClasses.SwordItem;

        public byte category => 9;

        public short uses => 1561;
        public float speed => 8f;
        public float attack_damage_bonus => 3f;
        public byte level => 3;
        public byte enchantment_value => 10;
        public float attack_damage => 6f;
    }
}
