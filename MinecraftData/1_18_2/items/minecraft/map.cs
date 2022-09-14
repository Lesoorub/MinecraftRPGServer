using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.map)]
    public class map : IBaseItem, IHasCategory, IIsComplex
    {
        public short id => 951;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.map";
        public ItemClasses @class => ItemClasses.EmptyMapItem;

        public byte category => 6;

        public bool is_complex => true;
    }
}
