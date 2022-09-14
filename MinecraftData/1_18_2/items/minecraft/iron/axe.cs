using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.iron_axe)]
    public class iron_axe : IBaseItem, IHasCategory, ITool, IAxe
    {
        public short id => 717;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 250;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.iron_axe";
        public ItemClasses @class => ItemClasses.AxeItem;

        public byte category => 8;

        public short uses => 250;
        public float speed => 6f;
        public float attack_damage_bonus => 2f;
        public byte level => 2;
        public byte enchantment_value => 14;
        public float attack_damage => 8f;

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
