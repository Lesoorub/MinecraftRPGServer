using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.trident)]
    public class trident : IBaseItem, IHasCategory
    {
        public short id => 1029;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 250;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.trident";
        public ItemClasses @class => ItemClasses.TridentItem;

        public byte category => 9;
    }
}
