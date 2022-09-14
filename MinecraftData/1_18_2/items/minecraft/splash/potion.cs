using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.splash_potion)]
    public class splash_potion : IBaseItem, IHasCategory
    {
        public short id => 1005;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.splash_potion";
        public ItemClasses @class => ItemClasses.SplashPotionItem;

        public byte category => 10;
    }
}
