using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.shield)]
    public class shield : IBaseItem, IHasCategory
    {
        public short id => 1009;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 336;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.shield";
        public ItemClasses @class => ItemClasses.ShieldItem;

        public byte category => 9;
    }
}
