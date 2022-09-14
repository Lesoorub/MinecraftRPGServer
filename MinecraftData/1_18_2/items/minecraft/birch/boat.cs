using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.birch_boat)]
    public class birch_boat : IBaseItem, IHasCategory
    {
        public short id => 672;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.birch_boat";
        public ItemClasses @class => ItemClasses.BoatItem;

        public byte category => 3;
    }
}
