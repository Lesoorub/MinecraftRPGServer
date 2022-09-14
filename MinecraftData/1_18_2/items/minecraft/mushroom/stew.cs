using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.mushroom_stew)]
    public class mushroom_stew : IBaseItem, IHasCategory, IFood
    {
        public short id => 731;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.mushroom_stew";
        public ItemClasses @class => ItemClasses.StewItem;

        public byte category => 7;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 6,
            saturation_modifier = 0.6f,
            is_meat = false,
            can_always_eat = false,
            fast_food = false
        };
    }
}
