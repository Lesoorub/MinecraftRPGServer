using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.scaffolding)]
    public class scaffolding : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 584;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.scaffolding";
        public ItemClasses @class => ItemClasses.ScaffoldingItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.scaffolding;
    }
}
