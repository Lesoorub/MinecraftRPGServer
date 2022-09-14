using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.spruce_boat)]
    public class spruce_boat : IBaseItem, IHasCategory
    {
        public short id => 671;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.spruce_boat";
        public ItemClasses @class => ItemClasses.BoatItem;

        public byte category => 3;
    }
}
