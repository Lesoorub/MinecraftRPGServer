using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.diamond_hoe)]
    public class diamond_hoe : IBaseItem, IHasCategory, ITool
    {
        public short id => 723;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 1561;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.diamond_hoe";
        public ItemClasses @class => ItemClasses.HoeItem;

        public byte category => 8;

        public short uses => 1561;
        public float speed => 8f;
        public float attack_damage_bonus => 3f;
        public byte level => 3;
        public byte enchantment_value => 10;
        public float attack_damage => 0f;
    }
}
