using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.sunflower)]
    public class sunflower : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 394;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.sunflower";
        public ItemClasses @class => ItemClasses.TallBlockItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.sunflower;
    }
}
