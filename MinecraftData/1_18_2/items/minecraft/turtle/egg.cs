using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.turtle_egg)]
    public class turtle_egg : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 516;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.turtle_egg";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 6;

        public BlockNameID block => BlockNameID.turtle_egg;
    }
}
