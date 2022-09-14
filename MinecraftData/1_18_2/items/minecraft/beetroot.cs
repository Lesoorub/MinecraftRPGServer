using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.beetroot)]
    public class beetroot : IBaseItem, IHasCategory, IFood
    {
        public short id => 1001;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.beetroot";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 7;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 1,
            saturation_modifier = 0.6f,
            is_meat = false,
            can_always_eat = false,
            fast_food = false
        };
    }
}
