using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.ender_eye)]
    public class ender_eye : IBaseItem, IHasCategory
    {
        public short id => 871;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.ender_eye";
        public ItemClasses @class => ItemClasses.EnderEyeItem;

        public byte category => 6;
    }
}
