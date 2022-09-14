using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.activator_rail)]
    public class activator_rail : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 660;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.activator_rail";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 3;

        public BlockNameID block => BlockNameID.activator_rail;
    }
}
