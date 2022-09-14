using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.golden_axe)]
    public class golden_axe : IBaseItem, IHasCategory, ITool, IAxe
    {
        public short id => 712;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 32;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.golden_axe";
        public ItemClasses @class => ItemClasses.AxeItem;

        public byte category => 8;

        public short uses => 32;
        public float speed => 12f;
        public float attack_damage_bonus => 0f;
        public byte level => 0;
        public byte enchantment_value => 22;
        public float attack_damage => 6f;

        public Dictionary<short, short> strippables_blocks => new Dictionary<short, short>() 
        {
            { 38, 49 },
            { 39, 44 },
            { 40, 45 },
            { 41, 46 },
            { 42, 47 },
            { 43, 48 },
            { 50, 56 },
            { 51, 57 },
            { 52, 58 },
            { 53, 59 },
            { 54, 60 },
            { 55, 61 },
            { 697, 698 },
            { 699, 700 },
            { 706, 707 },
            { 708, 709 }
        };
    }
}
