using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.small_amethyst_bud)]
    public class small_amethyst_bud : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 1096;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.small_amethyst_bud";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.small_amethyst_bud;
    }
}
