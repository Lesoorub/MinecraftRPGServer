using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.furnace_minecart)]
    public class furnace_minecart : IBaseItem, IHasCategory
    {
        public short id => 664;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.furnace_minecart";
        public ItemClasses @class => ItemClasses.MinecartItem;

        public byte category => 3;
    }
}
