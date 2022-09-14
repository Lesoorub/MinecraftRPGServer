using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.blaze_rod)]
    public class blaze_rod : IBaseItem, IHasCategory
    {
        public short id => 859;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.blaze_rod";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
