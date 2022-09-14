using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.light_blue_dye)]
    public class light_blue_dye : IBaseItem, IHasCategory, IDye
    {
        public short id => 813;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.light_blue_dye";
        public ItemClasses @class => ItemClasses.DyeItem;

        public byte category => 6;

        public string dye_color => "light_blue";
    }
}
