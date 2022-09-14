using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.spectral_arrow)]
    public class spectral_arrow : IBaseItem, IHasCategory
    {
        public short id => 1006;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.spectral_arrow";
        public ItemClasses @class => ItemClasses.SpectralArrowItem;

        public byte category => 9;
    }
}
