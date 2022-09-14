using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.flint_and_steel)]
    public class flint_and_steel : IBaseItem, IHasCategory
    {
        public short id => 680;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 64;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.flint_and_steel";
        public ItemClasses @class => ItemClasses.FlintAndSteelItem;

        public byte category => 8;
    }
}
