using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.totem_of_undying)]
    public class totem_of_undying : IBaseItem, IHasCategory
    {
        public short id => 1010;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.totem_of_undying";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 9;
    }
}
