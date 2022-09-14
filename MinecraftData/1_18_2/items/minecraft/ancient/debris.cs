using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.ancient_debris)]
    public class ancient_debris : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 58;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => true;
        public string translation_key => "block.minecraft.ancient_debris";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 0;

        public BlockNameID block => BlockNameID.ancient_debris;
    }
}
