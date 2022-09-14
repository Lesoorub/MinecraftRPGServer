using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.painting)]
    public class painting : IBaseItem, IHasCategory
    {
        public short id => 765;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.painting";
        public ItemClasses @class => ItemClasses.DecorationItem;

        public byte category => 1;
    }
}
