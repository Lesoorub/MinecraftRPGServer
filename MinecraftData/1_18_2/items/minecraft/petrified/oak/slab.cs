using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.petrified_oak_slab)]
    public class petrified_oak_slab : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 216;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.petrified_oak_slab";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.petrified_oak_slab;
    }
}
