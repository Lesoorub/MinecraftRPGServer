using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.crimson_sign)]
    public class crimson_sign : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 774;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.crimson_sign";
        public ItemClasses @class => ItemClasses.SignItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.crimson_sign;
    }
}
