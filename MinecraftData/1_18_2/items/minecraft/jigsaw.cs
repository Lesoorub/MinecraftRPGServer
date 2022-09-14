using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.jigsaw)]
    public class jigsaw : IBaseItem, ICanPlaceBlock
    {
        public short id => 677;
        public Rarity rarity => Rarity.epic;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.jigsaw";
        public ItemClasses @class => ItemClasses.CommandBlockItem;

        public BlockNameID block => BlockNameID.jigsaw;
    }
}
