using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.crimson_fence_gate)]
    public class crimson_fence_gate : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 655;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.crimson_fence_gate";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 2;

        public BlockNameID block => BlockNameID.crimson_fence_gate;
    }
}
