using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.hopper_minecart)]
    public class hopper_minecart : IBaseItem, IHasCategory
    {
        public short id => 666;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.hopper_minecart";
        public ItemClasses @class => ItemClasses.MinecartItem;

        public byte category => 3;
    }
}
