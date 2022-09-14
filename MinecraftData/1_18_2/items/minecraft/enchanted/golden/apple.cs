using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.enchanted_golden_apple)]
    public class enchanted_golden_apple : IBaseItem, IHasCategory, IFood
    {
        public short id => 767;
        public Rarity rarity => Rarity.epic;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.enchanted_golden_apple";
        public ItemClasses @class => ItemClasses.EnchantedGoldenAppleItem;

        public byte category => 7;

        public food_properties food_properties => new food_properties()
        {
            nutrition = 4,
            saturation_modifier = 1.2f,
            is_meat = false,
            can_always_eat = true,
            fast_food = false
        };
    }
}
