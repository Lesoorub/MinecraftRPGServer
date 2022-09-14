using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.cod)]
    public class cod : IBaseItem, IHasCategory, IFood
    {
        public short id => 801;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.cod";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 7;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 2,
            saturation_modifier = 0.1f,
            is_meat = false,
            can_always_eat = false,
            fast_food = false
        };
    }
}
