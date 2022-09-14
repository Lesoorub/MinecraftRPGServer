using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.golden_hoe)]
    public class golden_hoe : IBaseItem, IHasCategory, ITool
    {
        public short id => 713;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 32;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.golden_hoe";
        public ItemClasses @class => ItemClasses.HoeItem;

        public byte category => 8;

        public short uses => 32;
        public float speed => 12f;
        public float attack_damage_bonus => 0f;
        public byte level => 0;
        public byte enchantment_value => 22;
        public float attack_damage => 0f;
    }
}
