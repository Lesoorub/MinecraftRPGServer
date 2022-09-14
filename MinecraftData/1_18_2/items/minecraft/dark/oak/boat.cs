using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.dark_oak_boat)]
    public class dark_oak_boat : IBaseItem, IHasCategory
    {
        public short id => 675;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.dark_oak_boat";
        public ItemClasses @class => ItemClasses.BoatItem;

        public byte category => 3;
    }
}
