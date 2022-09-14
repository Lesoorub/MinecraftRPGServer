using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.lily_pad)]
    public class lily_pad : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 304;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.lily_pad";
        public ItemClasses @class => ItemClasses.LilyPadItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.lily_pad;
    }
}
