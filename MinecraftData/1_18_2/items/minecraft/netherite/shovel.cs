using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.netherite_shovel)]
    public class netherite_shovel : IBaseItem, IHasCategory, ITool, IHovel
    {
        public short id => 725;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 2031;
        public bool is_fire_resistant => true;
        public string translation_key => "item.minecraft.netherite_shovel";
        public ItemClasses @class => ItemClasses.ShovelItem;

        public byte category => 8;

        public short uses => 2031;
        public float speed => 9f;
        public float attack_damage_bonus => 4f;
        public byte level => 4;
        public byte enchantment_value => 15;
        public float attack_damage => 5.5f;

        public Dictionary<short, short> flattenables_block_states => new Dictionary<short, short>() 
        {
            { 8, 9473 },
            { 9, 9473 },
            { 10, 9473 },
            { 11, 9473 },
            { 262, 9473 },
            { 870, 9473 }
        };
    }
}
