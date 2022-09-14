using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.golden_carrot)]
    public class golden_carrot : IBaseItem, IHasCategory, IFood
    {
        public short id => 952;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.golden_carrot";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 10;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 6,
            saturation_modifier = 1.2f,
            is_meat = false,
            can_always_eat = false,
            fast_food = false
        };
    }
}
