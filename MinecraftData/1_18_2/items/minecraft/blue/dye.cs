using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.blue_dye)]
    public class blue_dye : IBaseItem, IHasCategory, IDye
    {
        public short id => 821;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.blue_dye";
        public ItemClasses @class => ItemClasses.DyeItem;

        public byte category => 6;

        public string dye_color => "blue";
    }
}
