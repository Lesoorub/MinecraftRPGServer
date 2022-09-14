using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.beetroot_soup)]
    public class beetroot_soup : IBaseItem, IHasCategory, IFood
    {
        public short id => 1003;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.beetroot_soup";
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
