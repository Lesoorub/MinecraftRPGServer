using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.redstone_torch)]
    public class redstone_torch : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 586;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.redstone_torch";
        public ItemClasses @class => ItemClasses.WallStandingBlockItem;

        public byte category => 2;

        public BlockNameID block => BlockNameID.redstone_torch;
    }
}
