using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.experience_bottle)]
    public class experience_bottle : IBaseItem, IHasCategory
    {
        public short id => 940;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.experience_bottle";
        public ItemClasses @class => ItemClasses.ExperienceBottleItem;

        public byte category => 6;
    }
}
