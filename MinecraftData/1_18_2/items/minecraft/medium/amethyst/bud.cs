using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.medium_amethyst_bud)]
    public class medium_amethyst_bud : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 1097;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.medium_amethyst_bud";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.medium_amethyst_bud;
    }
}
