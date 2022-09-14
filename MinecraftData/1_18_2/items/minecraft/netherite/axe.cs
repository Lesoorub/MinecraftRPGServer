using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_axe)]
    public class netherite_axe : IBaseItem, IHasCategory, ITool, IAxe
    {
        public short id => 727;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 2031;
        public bool is_fire_resistant => true;
        public string translation_key => "item.minecraft.netherite_axe";
        public ItemClasses @class => ItemClasses.AxeItem;

        public byte category => 8;

        public short uses => 2031;
        public float speed => 9f;
        public float attack_damage_bonus => 4f;
        public byte level => 4;
        public byte enchantment_value => 15;
        public float attack_damage => 9f;

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
