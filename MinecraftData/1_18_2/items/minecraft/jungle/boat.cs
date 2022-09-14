using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.jungle_boat)]
    public class jungle_boat : IBaseItem, IHasCategory
    {
        public short id => 673;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.jungle_boat";
        public ItemClasses @class => ItemClasses.BoatItem;

        public byte category => 3;
    }
}
