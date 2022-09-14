using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.heart_of_the_sea)]
    public class heart_of_the_sea : IBaseItem, IHasCategory
    {
        public short id => 1032;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.heart_of_the_sea";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
