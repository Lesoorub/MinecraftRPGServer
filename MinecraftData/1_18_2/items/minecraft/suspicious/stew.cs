using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.suspicious_stew)]
    public class suspicious_stew : IBaseItem, IFood
    {
        public short id => 1034;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.suspicious_stew";
        public ItemClasses @class => ItemClasses.SuspiciousStewItem;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 6,
            saturation_modifier = 0.6f,
            is_meat = false,
            can_always_eat = true,
            fast_food = false
        };
    }
}
