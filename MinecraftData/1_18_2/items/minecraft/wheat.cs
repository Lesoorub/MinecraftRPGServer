using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.wheat)]
    public class wheat : IBaseItem, IHasCategory
    {
        public short id => 736;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.wheat";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
