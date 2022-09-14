using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.bow)]
    public class bow : IBaseItem, IHasCategory
    {
        public short id => 682;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 384;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.bow";
        public ItemClasses @class => ItemClasses.BowItem;

        public byte category => 9;
    }
}
