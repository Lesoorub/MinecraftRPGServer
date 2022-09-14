using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.saddle)]
    public class saddle : IBaseItem, IHasCategory
    {
        public short id => 661;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.saddle";
        public ItemClasses @class => ItemClasses.SaddleItem;

        public byte category => 3;
    }
}
