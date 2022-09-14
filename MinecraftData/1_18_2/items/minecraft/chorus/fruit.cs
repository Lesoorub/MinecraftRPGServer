using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.chorus_fruit)]
    public class chorus_fruit : IBaseItem, IHasCategory, IFood
    {
        public short id => 999;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.chorus_fruit";
        public ItemClasses @class => ItemClasses.ChorusFruitItem;

        public byte category => 6;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 4,
            saturation_modifier = 0.3f,
            is_meat = false,
            can_always_eat = true,
            fast_food = false
        };
    }
}
