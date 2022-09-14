using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.jack_o_lantern)]
    public class jack_o_lantern : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 267;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.jack_o_lantern";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.jack_o_lantern;
    }
}
