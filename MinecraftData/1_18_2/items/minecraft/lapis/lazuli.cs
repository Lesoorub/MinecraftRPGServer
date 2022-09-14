using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.lapis_lazuli)]
    public class lapis_lazuli : IBaseItem, IHasCategory
    {
        public short id => 688;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.lapis_lazuli";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
