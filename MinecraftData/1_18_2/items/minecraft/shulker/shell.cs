using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.shulker_shell)]
    public class shulker_shell : IBaseItem, IHasCategory
    {
        public short id => 1011;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.shulker_shell";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
