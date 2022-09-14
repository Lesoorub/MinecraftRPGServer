using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.nether_star)]
    public class nether_star : IBaseItem, IHasCategory
    {
        public short id => 959;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.nether_star";
        public ItemClasses @class => ItemClasses.NetherStarItem;

        public byte category => 6;
    }
}
