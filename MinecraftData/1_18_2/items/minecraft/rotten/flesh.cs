using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.rotten_flesh)]
    public class rotten_flesh : IBaseItem, IHasCategory, IFood
    {
        public short id => 857;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.rotten_flesh";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 7;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 4,
            saturation_modifier = 0.1f,
            is_meat = true,
            can_always_eat = false,
            fast_food = false
        };
    }
}
