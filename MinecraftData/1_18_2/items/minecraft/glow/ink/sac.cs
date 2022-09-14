using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.glow_ink_sac)]
    public class glow_ink_sac : IBaseItem, IHasCategory
    {
        public short id => 808;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.glow_ink_sac";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 6;
    }
}
