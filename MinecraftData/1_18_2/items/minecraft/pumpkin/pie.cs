using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.pumpkin_pie)]
    public class pumpkin_pie : IBaseItem, IHasCategory, IFood
    {
        public short id => 960;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.pumpkin_pie";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 7;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 8,
            saturation_modifier = 0.3f,
            is_meat = false,
            can_always_eat = false,
            fast_food = false
        };
    }
}
