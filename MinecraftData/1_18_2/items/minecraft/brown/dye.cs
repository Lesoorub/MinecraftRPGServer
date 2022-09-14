using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.brown_dye)]
    public class brown_dye : IBaseItem, IHasCategory, IDye
    {
        public short id => 822;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.brown_dye";
        public ItemClasses @class => ItemClasses.DyeItem;

        public byte category => 6;

        public string dye_color => "brown";
    }
}
