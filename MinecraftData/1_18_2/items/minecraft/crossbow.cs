using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.crossbow)]
    public class crossbow : IBaseItem, IHasCategory
    {
        public short id => 1033;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 465;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.crossbow";
        public ItemClasses @class => ItemClasses.CrossbowItem;

        public byte category => 9;
    }
}
