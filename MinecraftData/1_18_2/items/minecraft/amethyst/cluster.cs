using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.amethyst_cluster)]
    public class amethyst_cluster : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 1099;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.amethyst_cluster";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.amethyst_cluster;
    }
}
