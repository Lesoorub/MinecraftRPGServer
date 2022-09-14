using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.stone_shovel)]
    public class stone_shovel : IBaseItem, IHasCategory, ITool, IHovel
    {
        public short id => 705;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 131;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.stone_shovel";
        public ItemClasses @class => ItemClasses.ShovelItem;

        public byte category => 8;

        public short uses => 131;
        public float speed => 4f;
        public float attack_damage_bonus => 1f;
        public byte level => 1;
        public byte enchantment_value => 5;
        public float attack_damage => 2.5f;

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
