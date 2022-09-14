using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.oak_fence_gate)]
    public class oak_fence_gate : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 649;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.oak_fence_gate";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 2;

        public BlockNameID block => BlockNameID.oak_fence_gate;
    }
}
