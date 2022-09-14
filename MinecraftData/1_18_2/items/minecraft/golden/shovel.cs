using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.golden_shovel)]
    public class golden_shovel : IBaseItem, IHasCategory, ITool, IHovel
    {
        public short id => 710;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 32;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.golden_shovel";
        public ItemClasses @class => ItemClasses.ShovelItem;

        public byte category => 8;

        public short uses => 32;
        public float speed => 12f;
        public float attack_damage_bonus => 0f;
        public byte level => 0;
        public byte enchantment_value => 22;
        public float attack_damage => 1.5f;

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
