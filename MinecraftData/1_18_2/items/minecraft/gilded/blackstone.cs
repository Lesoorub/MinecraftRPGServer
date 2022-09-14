using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.gilded_blackstone)]
    public class gilded_blackstone : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 1069;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.gilded_blackstone";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.gilded_blackstone;
    }
}
