using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.fishing_rod)]
    public class fishing_rod : IBaseItem, IHasCategory
    {
        public short id => 797;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 64;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.fishing_rod";
        public ItemClasses @class => ItemClasses.FishingRodItem;

        public byte category => 8;
    }
}
